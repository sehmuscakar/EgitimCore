using Giriş.Filters;
using Giriş.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Giriş.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string kelime)
        {
            ViewBag.UrunKategori = "Bilgisiyar";
            ViewData["UrunAdi"] = "Lapton";
            TempData["UrunFiyati"] = 200;
            //Cookie örnek
            TempData["CookieOku"] = Request.Cookies["urunadi"];//okuma işlemi yaptık
            //Session Örnek(oturum açma)

            TempData["SeesionOku"] = HttpContext.Session.GetString("kategori");//hangi isimi vermişsek o isimle çağırıyoruz
            return View();
        }
        [HttpPost]
        public IActionResult Index(string urunkategorisi,string urunAdi,string urunFiyati)
        {
            ViewBag.UrunKategori = urunkategorisi;
            ViewData["UrunAdi"] = urunAdi;
            TempData["UrunFiyati"] = urunFiyati;
            //Cookie örnek
            Response.Cookies.Append("urunadi", urunAdi);//yazdırıken , birinci paremtre ismi ikincisi key değeri

            //Session Örnek(oturum açma)
            HttpContext.Session.SetString("kategori",urunkategorisi);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [UserControl]
        public IActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FileUpload(IFormFile Image)
        {
            if (Image is not null)
            {
                string klasor = Directory.GetCurrentDirectory() + "wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(klasor, FileMode.Create);
            Image.CopyTo(stream);
                TempData["Resim"] = Image.FileName;
            }

            return View();
        }
        public IActionResult ModelKullanimi()
        {
            var model = new Urun
            {
                Name= "Bilgisiyar",
                Description="Bilgisiyar Açıklaması",
                Price=1800
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ModelKullanimi(Urun urun)
        {
            return View(urun);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}