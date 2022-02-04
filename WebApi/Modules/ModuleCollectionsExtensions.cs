using Core.Attributes;

namespace Api.Modules
{
    public static class ModuleCollectionsExtensions
    {
        public interface IModule
        {
            IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
        }

        /// <summary>
        /// Registra todo los enpoints de los modulos que hereden de Imodule
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            var registeredModules = typeof(IModule).Assembly
                                        .GetTypes()
                                    .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                                        .Select(Activator.CreateInstance)
                                    .Cast<IModule>();

            foreach (var module in registeredModules)
            {
                module.MapEndpoints(app);
            }

            return app;
        }
    }
}
