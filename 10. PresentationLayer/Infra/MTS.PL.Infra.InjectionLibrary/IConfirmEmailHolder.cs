namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IConfirmEmailHolder
    {
        string Code { get; set; }
        string UserId { get; set; }
    }
}