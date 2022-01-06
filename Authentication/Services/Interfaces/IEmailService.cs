using Authentication.Entities;

namespace Authentication.Services.Interfaces
{
    //Interfaz para el servicio de Email
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
