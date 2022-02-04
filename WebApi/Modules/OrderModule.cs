using static Api.Modules.ModuleCollectionsExtensions;

namespace Api.Modules
{
    public class OrderModule : IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/orders", () =>
            {
                // Ejemplo (Deberia ir en un servicio la logica)
                var foods = new[]
                {
                    "Ensalada", "Carne", "Pollo", "Helado", "Jugo", "Cerdo"
                };

                var orders = Enumerable.Range(1, 5).Select(index =>
                                      new Order
                                      (
                                          index,
                                          Random.Shared.Next(-20, 55),
                                          foods[Random.Shared.Next(foods.Length)]
                                      ))
                                       .ToArray();
                return orders;
            });

            endpoints.MapPost("/orders", () =>
            {

            });

            return endpoints;
        }

    }

    internal record Order(int id, int price, string? food)
    {
        public int priceF => 32 + (int)(price / 0.5556);
    }
}
