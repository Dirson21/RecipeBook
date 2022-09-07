using Application.Dto;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Security.Claims;

namespace RecipeBookBackend.Filters
{
    public class ValidateOwnerRecipeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {


        }
    }
}
