namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface ICredit
    {
        int Id { get; set; }
        string MadeBy { get; set; }
        string GotFrom { get; set; }
        string LinkToImage { get; set; }
        string AuthorWebsite { get; set; }
    }
}