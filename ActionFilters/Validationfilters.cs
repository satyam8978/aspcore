using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace AspCorePractie.ActionFilters
{
    public class Validationfilters: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments.SingleOrDefault(p => p.Value is IEntity);
          
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}

