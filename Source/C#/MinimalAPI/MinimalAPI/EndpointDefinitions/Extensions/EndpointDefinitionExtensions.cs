namespace MinimalAPI.EndpointDefinitions.Extensions
{
    internal static class EndpointDefinitionExtensions
    {
        public static void AddEndpointDefinitionsFromAssembly(this IServiceCollection services, params Type[] types)
        {
            var endpointDefinitions = new List<IEndpointDefinition>();

            foreach ( var type in types )
            {
                endpointDefinitions.AddRange(type.Assembly.DefinedTypes.Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface).Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
            }

            foreach ( var endpointDefinition in endpointDefinitions)
            {
                endpointDefinition.DefineServices(services);
            }

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinition>);
        }

        public static void UseEndpointsDefinition(this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

            foreach ( var definition in definitions )
            {
                definition.DefineEndpoints(app);
            }
        }

    }
}
