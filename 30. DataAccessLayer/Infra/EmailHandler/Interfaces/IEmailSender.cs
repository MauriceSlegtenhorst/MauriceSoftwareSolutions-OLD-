using System.Threading.Tasks;

namespace MTS.PL.Infra.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
