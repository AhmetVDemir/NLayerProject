using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using UNLayerP.API.DTOs;
using UNLayerP.Core.Services;

namespace UNLayerP.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errDtyo = new ErrorDto();
                errDtyo.Status = 404;
                errDtyo.Errors.Add($"id'si {id} olan ürün veritabanında bulunamadı.");
                context.Result = new NotFoundObjectResult(errDtyo);
            }
        }

    }
}
