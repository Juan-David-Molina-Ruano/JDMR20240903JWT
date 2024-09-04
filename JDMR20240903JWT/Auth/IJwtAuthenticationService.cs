namespace JDMR20240903JWT.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string username);

    }
}
