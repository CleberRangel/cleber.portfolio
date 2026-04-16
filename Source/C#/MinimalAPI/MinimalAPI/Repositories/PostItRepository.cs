using MinimalAPI.Models;

namespace MinimalAPI.Repositories
{
    internal class PostItRepository : IPostItRepository
    {
        private readonly Dictionary<Guid, PostIt> _postitStore = new();

        public List<PostIt> GetAll()
        {
            return _postitStore.Values.ToList();
        }

        public PostIt? GetById(Guid id)
        {
            _postitStore.TryGetValue(id, out PostIt? postIt);

            return postIt;
        }

        void IPostItRepository.Create(PostIt? postIt)
        {
            if (postIt is null)
            {
                return;
            }

            _postitStore[postIt.Id] = postIt;
        }

        void IPostItRepository.Delete(Guid id)
        {
            _postitStore.Remove(id);
        }

        void IPostItRepository.Update(PostIt? postIt)
        {
            if (postIt is null)
            {
                return;
            }

            var existingPostIt = GetById(postIt.Id);

            if (existingPostIt is null)
            {
                return;
            }

            _postitStore[postIt.Id] = postIt;

        }
    }
}
