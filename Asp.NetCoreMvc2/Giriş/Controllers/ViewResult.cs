using Giriş.Models;
using Microsoft.AspNetCore.Mvc;

namespace Giriş.Controllers
{
    public class ViewResult : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Yonlendir()
        {
            return Redirect("Home/Index");//home controller,Index action
        }
        public IActionResult ActionaYonlendir()
        {
            return RedirectToAction("Index","Home");//ındex action,Home cantroller
        }

        public IActionResult RouteYonlendir()
        {
            return RedirectToAction("default",new {Controller="Home",action="Index",id=18});//default route deki name ismidir.
        }

        public JsonResult JsonDondur()
        {
            var urun = new Urun()
            {
                Name="mobilya",Price=6000,Id=22
            };

            return Json(urun);
        }

        public IActionResult XmlContentResult()
        {

            var xml = @"

<kullanicilar>
<kullanici>
<Id>2</Id>
<Name>Şehmus</Name>
<Surname>çakar</Surname>
</kullanici>
<kullanici>
<Id>3</Id>
<Name>Yavuz</Name>
<Surname>Kara</Surname>
</kullanici>
</kullanicilar>


";
            return Content(xml,"application/xml"); //"application/xml" bunu eklersen xml şeklinde döndürür
        }

    }
}
