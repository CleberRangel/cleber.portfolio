using FluentValidation;
using MinimalAPI.Models;

namespace MinimalAPI.Validations
{
    internal class PostItValidator : AbstractValidator<PostIt>
    {
        public PostItValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Column).NotEmpty();
        }
    }
}
