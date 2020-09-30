using System;

namespace MTS.BL.Infra.Interfaces.Standard.Credit
{
    public interface IBLCredit
    {
        Guid CreditCategoryFK { get; set; }
        Guid CreditId { get; set; }
        string Description { get; set; }
        string GotFrom { get; set; }
        string LinkToImage { get; set; }
        string MadeBy { get; set; }
        string SubTitle { get; set; }
        string Title { get; set; }
    }
}