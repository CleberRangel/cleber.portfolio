using MinimalAPI.Models;

namespace MinimalAPI.Repositories
{
    internal interface IPostItRepository
    {
        void Create(PostIt? postIt);
        void Update(PostIt? postIt);
        void Delete(Guid id);
        PostIt? GetById(Guid id);
        List<PostIt> GetAll();
    }
}
