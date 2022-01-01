using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UNLayerP.API.DTOs;

namespace UNLayerP.API.Filters
{

    public class ValidationFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto ed = new ErrorDto();
                ed.Status = 400;
                IEnumerable<ModelError> ModelError = context.ModelState.Values.SelectMany(v => v.Errors);
                ModelError.ToList().ForEach(x =>
                {
                    ed.Errors.Add(x.ErrorMessage);
                });
                context.Result = new BadRequestObjectResult(ed);
            }
        }
    }
}
