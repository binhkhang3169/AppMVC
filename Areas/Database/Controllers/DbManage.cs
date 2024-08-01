using App.Data;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;

namespace App.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/{action}")]
    public class DbManage : Controller
    {
        private readonly AppDBContext _appDb;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbManage(AppDBContext appDb, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _appDb = appDb;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: DbManage
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDB()
        {
            return View();
        }
        // public string StatusMessage{get;set;}

        [HttpPost]
        public async Task<IActionResult> DeleteDBAsync()
        {
            var success = await _appDb.Database.EnsureDeletedAsync();
            // StatusMessage  = success?"Xoa thanh cong":"xoa khong thanh cong";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Migration()
        {
            return View();
        }
        // public string StatusMessage{get;set;}

        [HttpPost]
        public async Task<IActionResult> MigrationAsync()
        {
            await _appDb.Database.MigrateAsync();
            // StatusMessage  = success?"Xoa thanh cong":"xoa khong thanh cong";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> SeedDataAsync()
        {
            var rolenames = typeof(RoleName).GetFields().ToList();
            foreach (var role in rolenames)
            {
                var rolename = (string)role.GetRawConstantValue();
                var rfound = await _roleManager.FindByNameAsync(rolename);
                if (rfound == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(rolename));
                }
            }

            // admin pass =123123
            var useradmin = await _userManager.FindByEmailAsync("admin@example.com");
            if (useradmin == null)
            {
                useradmin = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                };
                await _userManager.CreateAsync(useradmin, "123123");
                await _userManager.AddToRoleAsync(useradmin, RoleName.Administrator);
            }
            return RedirectToAction("Index");
        }
    }
}
