using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTS.PL.Infra.InjectionLibrary
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}
