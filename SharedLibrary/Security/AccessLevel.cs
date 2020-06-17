using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Security
{
    public enum AccessLevel
    {
        UnauthorizedUser,
        StandardUser,
        PrivilegedUser,
        Volenteer,
        Employee,
        PrivilegedEmployee,
        Administrator
    }
}
