using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace MTS.DAL.API.Utils.ExceptionHandler
{
    public sealed class ExceptionHandler : ControllerBase, IExceptionHandler
    {
        public IActionResult HandleException(Exception ex, bool isServerSideException)
        {
#if DEBUG
            int size = ex.InnerException == null ? 8 : 16;

            var messagesHolder = new string[size];

            messagesHolder[0] = "Exception:";
            messagesHolder[1] = ex.GetType().Name;
            messagesHolder[2] = "Source application or object:";
            messagesHolder[3] = ex.Source;
            messagesHolder[4] = "Message:";
            messagesHolder[5] = ex.Message;
            messagesHolder[6] = "Stack trace:";
            messagesHolder[7] = ex.StackTrace;

            if (ex.InnerException != null)
            {
                messagesHolder[8] = "Inner exception:";
                messagesHolder[9] = ex.InnerException.GetType().Name;
                messagesHolder[10] = "Source application or object:";
                messagesHolder[11] = ex.InnerException.Source;
                messagesHolder[12] = "Message:";
                messagesHolder[13] = ex.InnerException.Message;
                messagesHolder[14] = "Stack trace:";
                messagesHolder[15] = ex.InnerException.StackTrace;
            }

            if (isServerSideException)
                return StatusCode(StatusCodes.Status500InternalServerError, messagesHolder);
            else
                return StatusCode(StatusCodes.Status400BadRequest, messagesHolder);

#else

            if(isServerSideException)
                return StatusCode(StatusCodes.Status500InternalServerError, new[] { "Something went wrong on the server. Details are held secret" });
            else
                return StatusCode(StatusCodes.Status400BadRequest, new[] { "Something went wrong client side resulting in error(s) on the server. Details are held secret" });
#endif

        }
    }
}
