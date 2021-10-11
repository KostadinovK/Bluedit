using System;
using BlueditServer.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BlueditServer.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiController
    {
        [AllowAnonymous]
        public ErrorResponseModel Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = 500;

            if (exception is ArgumentException)
            {
                code = 400;
            }

            Response.StatusCode = code;

            return new ErrorResponseModel(exception.Message, code);
        }
    }
}
