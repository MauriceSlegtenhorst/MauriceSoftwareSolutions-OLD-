using System;

namespace MTS.PL.Infra.InjectionLibrary
{
    public interface IUserToken
    {
        DateTime Expiration { get; set; }
        string LoginProvider { get; set; }
        string Name { get; set; }
        string UserId { get; set; }
        string Value { get; set; }
    }
}