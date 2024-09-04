namespace JDMR20240903JWT.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<object> data = new List<object>();

        public static void AddCategoriaProductoEndpoints(this WebApplication app)
        {
            app.MapGet("/categoriaproducto", () =>
            {
                return data;
            }).AllowAnonymous();

            app.MapPost("/categoriaproducto", (string name, double descripcion) =>
            {
                var categoriaProducto = new
                {
                    name,
                    descripcion
                };

                data.Add(categoriaProducto);

                return Results.Ok("Categoria creada exitosamente");
            }).RequireAuthorization();
        }
    }
}
