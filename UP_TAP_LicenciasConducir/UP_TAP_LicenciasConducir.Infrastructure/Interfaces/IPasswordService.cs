namespace UP_TAP_LicenciasConducir.Infrastructure.Services
{
    public interface IPasswordService
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
