namespace Authentication.Services.Interfaces
{
    public interface IPasswordService
    {
        //interfaz para el servicio de contrasenia
        string GeneratePassword(int length);
    }
}
