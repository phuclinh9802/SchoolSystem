using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageSchool.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginRegister.Controllers
{

    public class RegisterController : Controller
    {
        private readonly SchoolContext _context;

        public RegisterController(SchoolContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,UserName,Password")] Registered Register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Register);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Registered reg)
        {
            var lc = _context.Register.Where(x => x.UserName == reg.UserName && x.Password == reg.Password).FirstOrDefault();
            if (lc == null)
            {
                reg.Error = "Wrong username/password! Please try again.";
                return View("Login", reg);
            }
            else
            {

                // HttpContext.Session.GetString(log.UserId.ToString());
                //HttpContext.Session.SetString("UserId", "reg.Id.ToString()");
                return RedirectToAction("Index", "Users");

            }

        }

    }
}
