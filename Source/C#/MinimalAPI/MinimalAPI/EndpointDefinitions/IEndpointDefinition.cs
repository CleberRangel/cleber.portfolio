namespace MinimalAPI.EndpointDefinitions
{
    internal interface IEndpointDefinition
    {
        /// <summary>
        /// All the Endpoint definitions should be create inside here.
        /// </summary>
        /// <param name="application"><see cref="WebApplication"/></param>
        void DefineEndpoints(WebApplication application);

        /// <summary>
        /// All the services  for the endpoint should be created inside here.
        /// </summary>
        /// <param name="services"> <see cref="IServiceCollection"/></param>
        void DefineServices(IServiceCollection services);
    }
}