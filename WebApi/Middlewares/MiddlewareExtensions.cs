namespace Api.Middlewares
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Midlewares
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
