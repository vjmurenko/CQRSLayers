using System.Threading.Tasks;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Filters
{
	public class CheckOrderFilterAttribute : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var dbContext = context.HttpContext.RequestServices.GetRequiredService<IDbContext>();
			var currentService = context.HttpContext.RequestServices.GetRequiredService<ICurrentUserService>();
			var id = (int) context.ActionArguments["id"];

			var count = await dbContext.Orders.CountAsync(o => o.Id == id && o.Email == currentService.Email);
			if (count != 1)
			{
				context.Result = new NotFoundResult();
			}

			await base.OnActionExecutionAsync(context, next);
		}
	}
}