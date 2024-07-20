using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Services;
namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger; 
        private readonly ProductServices _productServices;
        public FirstController(ILogger<FirstController> logger,ProductServices productModels)
        {
            _logger = logger;
            _productServices = productModels; 
        }
        public string Index(){
            
            _logger.LogInformation("Toi la logger");


            return "Toi la index cua first";
        }

        public IActionResult ReadMe(){
            var content =@"
            Xin chao cac ban,
            Cac ban dang hoc ASP.NET
            ";
            return Content(content,"text/plain ");
        }


        public ViewResult HelloWorld(string userName){
            if(string.IsNullOrEmpty(userName)){
                userName = "Khach";
            }

            return View("xinchao4",userName);
        }
        [AcceptVerbs("POST","GET")]
        public IActionResult ViewProduct(int? id){
            var product = _productServices.Where(p => p.Id==id).FirstOrDefault();

            if(product==null){
                TempData["Thong bao"] = "Khong ton tai san pham";
                return Redirect(Url.Action("Index","Home"));
            }
            
            return View(product);
        }
    }
}

