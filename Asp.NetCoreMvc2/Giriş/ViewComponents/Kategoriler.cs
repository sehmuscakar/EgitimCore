using Microsoft.AspNetCore.Mvc;

namespace Giriş.ViewComponents
{
    public class Kategoriler:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
