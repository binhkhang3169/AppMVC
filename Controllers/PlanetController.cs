using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class PlanetController:Controller
    {
        private readonly PlanetService _planetService;
        private readonly ILogger<PlanetController> _iLogger;
        public PlanetController(PlanetService planets, ILogger<PlanetController> logger){
            _planetService = planets;
            _iLogger = logger;
        }
        [Route("Hanhtinh.html")]
        public IActionResult Index(){
            return View();
        }

        public IActionResult Detail(int? id){
            var planet = _planetService.Where(p=>p.Id==id).FirstOrDefault();
            
            if(planet==null){
                TempData["Thong bao"] = "Khong ton tai san pham";
            }

            return View(planet);
        }
    }
}