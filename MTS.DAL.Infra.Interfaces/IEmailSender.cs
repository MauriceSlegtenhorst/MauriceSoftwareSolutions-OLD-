using System.Threading.Tasks;

namespace MTS.DAL.Infra.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
