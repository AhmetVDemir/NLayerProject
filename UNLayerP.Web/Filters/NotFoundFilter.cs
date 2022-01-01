using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using UNLayerP.Web.DTOs;
using UNLayerP.Web.ApiService;

namespace UNLayerP.Web.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int) context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryApiService.GetByIdAsync(id);
            if (category != null)
            {
                await next();
            }
            else
            {
                ErrorDto errDtyo = new ErrorDto();

                errDtyo.Errors.Add($"id'si {id} olan kategori veritabanında bulunamadı.");
                context.Result = new RedirectToActionResult("Error", "Home", errDtyo);
            }
        }

    }
}
