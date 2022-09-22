using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Security.Claims;



namespace RecipeBookBackend.Filters
{
    public class HttpErrorResponseAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
   
            throw new NotImplementedException();
        }
    }
}
