namespace MTS.PL.Infra.InjectionLibrary
{
    public interface IConfirmEmailHolder
    {
        string Code { get; set; }
        string UserId { get; set; }
    }
}