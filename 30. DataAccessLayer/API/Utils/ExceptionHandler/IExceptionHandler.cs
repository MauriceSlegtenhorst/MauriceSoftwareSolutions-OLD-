using Microsoft.AspNetCore.Mvc;
using System;

namespace MTS.BL.API.Utils.ExceptionHandler
{
    public interface IExceptionHandler
    {
        IActionResult HandleException(Exception ex, bool isServerSideException);
    }
}