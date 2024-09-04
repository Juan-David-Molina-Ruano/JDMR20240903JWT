using JDMR20240903JWT.Models;

namespace JDMR20240903JWT.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<Bodega> data = new List<Bodega>();

        public static void AddBodegaEndpoints(this WebApplication app)
        {
            //buscar por id
            app.MapGet("/bodega/{id}", (int id) =>
            {
                var bodega = data.FirstOrDefault(x => x.Id == id);
                if (bodega == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(bodega);
            }).RequireAuthorization();

            //crear
            app.MapPost("/bodega", (Bodega bodega) =>
            {
                if (bodega == null)
                {
                    return Results.BadRequest("Bodega no valida");
                }
                data.Add(bodega);
                return Results.Ok("Bodega creada exitosamente");
            }).RequireAuthorization();

            //modificar
            app.MapPut("/bodega/{id}", (int id, Bodega bodega) =>
            {
                var bodegaExistente = data.FirstOrDefault(x => x.Id == id);
                if (bodegaExistente == null)
                {
                    return Results.NotFound();
                }
                bodegaExistente.Nombre = bodega.Nombre;
                return Results.Ok("Bodega modificada exitosamente");
            }).RequireAuthorization();
        }

    }
}
