namespace MTS.BL.Infra.Interfaces.Standard
{
    public interface ICredentialHolder
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}