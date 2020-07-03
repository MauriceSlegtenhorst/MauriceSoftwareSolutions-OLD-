namespace MTS.PL.Infra.InjectionLibrary
{
    public interface ICredentialHolder
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}