using Microsoft.AspNetCore.Mvc;
using System;

namespace MTS.PL.API.Utils.ExceptionHandler
{
    public interface IExceptionHandler
    {
        IActionResult HandleException(Exception ex, bool isServerSideException);
    }
}