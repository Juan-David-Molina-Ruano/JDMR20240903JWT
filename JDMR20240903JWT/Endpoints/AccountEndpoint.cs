using JDMR20240903JWT.Auth;

namespace JDMR20240903JWT.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndpoint(this WebApplication app)
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {

                if (login == "admin" && password == "admin")
                {
                    var token = authService.Authenticate(login);
                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });

          
            app.MapPost("/account/logout", () =>
            {
                return Results.Ok("sesion cerrada");
            });

        }
    }
}
