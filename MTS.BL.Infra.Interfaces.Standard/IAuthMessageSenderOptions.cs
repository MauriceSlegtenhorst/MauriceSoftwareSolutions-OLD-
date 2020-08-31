namespace MTS.BL.Infra.Interfaces.Standard
{
    public interface IAuthMessageSenderOptions
    {
        string DefaultSenderDisplayName { get; set; }
        string DefaultSenderEmail { get; set; }
        string Domain { get; set; }
        string Key { get; set; }
        int Port { get; set; }
        bool RequiresAuthentication { get; set; }
        bool UseHtml { get; set; }
        string UserName { get; set; }
        bool UseSsl { get; set; }
    }
}