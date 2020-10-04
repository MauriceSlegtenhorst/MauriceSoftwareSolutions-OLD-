namespace MTS.PL.Infra.Interfaces.Standard.Credit
{
    public interface IPLCredit
    {
        string Title { get; set; }

        string SubTitle { get; set; }

        string Description { get; set; }

        string MadeBy { get; set; }

        string GotFrom { get; set; }

        string LinkToImage { get; set; }
    }
}