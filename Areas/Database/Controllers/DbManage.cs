using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/{action}")]
    public class DbManage : Controller
    {
        private readonly AppDBContext _appDb;

        public DbManage(AppDBContext appDb)
        {
            _appDb = appDb;
        }

        // GET: DbManage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDB(){
            return View();
        }
        // public string StatusMessage{get;set;}

        [HttpPost]
        public async Task<IActionResult> DeleteDBAsync(){
            var success = await _appDb.Database.EnsureDeletedAsync();
            // StatusMessage  = success?"Xoa thanh cong":"xoa khong thanh cong";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Migration(){
            return View();
        }
        // public string StatusMessage{get;set;}

        [HttpPost]
        public async Task<IActionResult> MigrationAsync(){
            await _appDb.Database.MigrateAsync();
            // StatusMessage  = success?"Xoa thanh cong":"xoa khong thanh cong";
            return RedirectToAction(nameof(Index));
        }

    }
}
