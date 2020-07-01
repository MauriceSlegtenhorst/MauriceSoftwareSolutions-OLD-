using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace MTS.BL.API.Utils.ExceptionHandler
{
    public sealed class ExceptionHandler : ControllerBase, IExceptionHandler
    {
        public IActionResult HandleException(Exception ex, bool isServerSideException)
        {
#if DEBUG
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Exception:");
            stringBuilder.AppendLine(ex.GetType().Name);
            stringBuilder.AppendLine($"Source application or object:");
            stringBuilder.AppendLine(ex.Source);
            stringBuilder.AppendLine($"Message:");
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine($"Stack trace:");
            stringBuilder.AppendLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                stringBuilder.AppendLine($"Inner exception:");
                stringBuilder.AppendLine(ex.InnerException.GetType().Name);
                stringBuilder.AppendLine($"Source application or object:");
                stringBuilder.AppendLine(ex.InnerException.Source);
                stringBuilder.AppendLine($"Message:");
                stringBuilder.AppendLine(ex.InnerException.Message);
                stringBuilder.AppendLine($"Stack trace:");
                stringBuilder.AppendLine(ex.InnerException.StackTrace);
            }

            if (isServerSideException)
                return StatusCode(StatusCodes.Status500InternalServerError, stringBuilder.ToString());
            else
                return StatusCode(StatusCodes.Status400BadRequest, stringBuilder.ToString());
#else
            return StatusCode(500, "Something went wrong on the server. Details are held secret");
            if(isServerSideException)
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong on the server. Details are held secret");
            else
                return StatusCode(StatusCodes.Status400BadRequest, "Something went wrong client side resulting in error(s) on the server. Details are held secret");
#endif

        }
    }
}
