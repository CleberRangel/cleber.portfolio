using FluentValidation;
using FluentValidation.AspNetCore;
using MinimalAPI.Models;
using MinimalAPI.Repositories;
using MinimalAPI.Validations;

namespace MinimalAPI.EndpointDefinitions
{
    internal class PostItEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication application)
        {
            application.MapGet("/postits", GetAll).WithName("GetAllPostIts").Produces<List<PostIt>>().WithOpenApi();

            application.MapGet("/postits/{id}", GetById).WithName("GetPostItById").Produces<PostIt>().WithOpenApi();

            application.MapPost("/postits", CreatePostIt).WithName("CreatePostIt").WithOpenApi();

            application.MapPut("/postits/{id}", Update).WithName("UpdatePostIt").WithOpenApi();

            application.MapDelete("/postits/{id}", Delete).WithName("DeletePostIt").WithOpenApi();
        }

        internal static IResult GetAll(IPostItRepository repo)
        {
            return Results.Ok(repo.GetAll());
        }

        internal static IResult GetById(IPostItRepository repo, Guid id)
        {
            var postIt = repo.GetById(id);

            return postIt is not null ? Results.Ok(postIt) : Results.NotFound();
        }

        internal static IResult CreatePostIt(IPostItRepository repo, IValidator<PostIt> validator, PostIt postIt)
        {
            postIt.Id = Guid.NewGuid();
            var validationResult = validator.Validate(postIt);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => new { errors = x.ErrorMessage });
                return Results.BadRequest(errors);
            }

            repo.Create(postIt);

            return Results.Created($"/postits/{postIt.Id}", postIt);
        }

        internal static IResult Update(IPostItRepository repo, Guid id, PostIt updatedPostIt)
        {
            var postIt = repo.GetById(id);
            if (postIt is null)
            {
                return Results.NotFound();
            }

            repo.Update(updatedPostIt);

            return Results.Ok(updatedPostIt);
        }

        internal static IResult Delete(IPostItRepository repo, Guid id)
        {
            repo.Delete(id);
            return Results.Ok();

        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<IPostItRepository, PostItRepository>();

            services.AddScoped<IValidator<PostIt>, PostItValidator>();
        }
    }
}
