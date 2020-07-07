using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MTS.DAL.Infra.Interfaces;

namespace MTS.DAL.Entities
{
    public class EFUserAccount : IdentityUser, IEFUserAccount
    {
        public override string Id { get => base.Id; set => base.Id = value; }

        #region Custom properties
        public string FirstName { get; set; }

        public string Affix { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return null;

                if (string.IsNullOrEmpty(LastName))
                    return FirstName;

                var stringBuilder = new StringBuilder(FirstName);

                if (!string.IsNullOrEmpty(Affix))
                    stringBuilder.Append($" {Affix}");

                stringBuilder.Append($" {LastName}");

                return stringBuilder.ToString();
            }
        }

        public bool IsAdmitted { get; set; }
        #endregion

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FullName))
                return Email;
            else
                return FullName;

        }
    }
}
