using System.Collections.Generic;

namespace MTS.PL.Infra.Interfaces.Standard.Credit
{
    public interface IPLCreditCategory
    {
        ICollection<IPLCredit> Credits { get; set; }
        string Description { get; set; }
        string SubTitle { get; set; }
        string Title { get; set; }
    }
}