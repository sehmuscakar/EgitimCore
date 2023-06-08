using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Giriş.Filters
{
    public class UserControl:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userGuid = context.HttpContext.Session.GetString("userGuid");
            var userCookie = context.HttpContext.Request.Cookies[userGuid];
            if (userGuid==null)
            
            {
                context.Result = new RedirectResult("/Home/Privacy");
            }

            base.OnActionExecuting(context);
        }



    }
}
