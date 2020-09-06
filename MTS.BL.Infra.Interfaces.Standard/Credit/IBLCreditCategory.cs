using System;
using System.Collections.Generic;

namespace MTS.BL.Infra.Interfaces.Standard.Credit
{
    public interface IBLCreditCategory
    {
        Guid CreditCategoryId { get; set; }
        ICollection<IBLCredit> Credits { get; set; }
        string Description { get; set; }
        string SubTitle { get; set; }
        string Title { get; set; }
    }
}