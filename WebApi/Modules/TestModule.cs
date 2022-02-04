using Microsoft.AspNetCore.Mvc;
using Domain.Services;
using static Api.Modules.ModuleCollectionsExtensions;

namespace Api.Modules
{
    public class TestModule : IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/tests/{id}", ([FromServices]TestService testService, [FromRouteAttribute]int id) =>
            {
                return testService.GetTestById(id);
            });

            endpoints.MapGet("/tests", ([FromServices]TestService testService) =>
            {
                return testService.GetTests();
            });

            return endpoints;
        }

    }
}
