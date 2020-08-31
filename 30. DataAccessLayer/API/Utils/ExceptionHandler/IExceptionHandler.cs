using Microsoft.AspNetCore.Mvc;
using System;

namespace MTS.DAL.API.Utils.ExceptionHandler
{
    public interface IExceptionHandler
    {
        IActionResult HandleException(Exception ex, bool isServerSideException);
    }
}