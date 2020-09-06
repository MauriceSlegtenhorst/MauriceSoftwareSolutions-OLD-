namespace MTS.PL.Infra.Interfaces.Standard.Credit
{
    public interface IPLCredit
    {
        string Description { get; set; }
        string GotFrom { get; set; }
        string GotFromWebsite { get; set; }
        string LinkToImage { get; set; }
        string MadeBy { get; set; }
        string MadeByWebsite { get; set; }
        string SubTitle { get; set; }
        string Title { get; set; }
    }
}