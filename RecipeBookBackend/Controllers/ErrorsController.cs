using Application.Dto;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBookBackend.Controllers
{


    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController: ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Your exception
            var code = 500; 

            if (exception is HttpStatusException statusException)
            {
                code = statusException.Status;
            }

            Response.StatusCode = code; 

            return new ErrorResponse(exception); 
        }
    }
}
