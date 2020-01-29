using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManageSchool.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Http.Authentication;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Web.Http;

namespace ManageSchool.AspNetCore.NewDb.Controllers
{
    public class UsersController : Controller
    {
        private readonly SchoolContext _context;                  public UsersController(SchoolContext context)         {             _context = context;         }
         public IActionResult Index()
        {
            //if (_context.Student.ToListAsync() == null)
            //{
            //    var a = _context.Student
            //        .Include("Class")
            //        .ToList()
            //        .GroupBy(e => e.ClassId)
            //        .Select(y => new EntireModel
            //        {
            //            ClassId = null,
            //            ClassName = null,
            //            Location = null,
            //            NumberStudents = 2
            //        }).ToList();
            //    return View("Index", a);
            //}
            var x = _context.Student                 .Include("Class")                 .ToList()                 .GroupBy(e => e.ClassId)                 .Select(y => new EntireModel                 { 
                    ClassId = y.FirstOrDefault().ClassId,
                    ClassName = y.First().Class.ClassName,
                    Location = y.First().Class.Location,                     NumberStudents = y.Count()                 }                 ).ToList();
             return View("Index", x);
            //return View();
        }
        //public IActionResult Popup1()
        //{
        //    return PartialView();
        //}
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Class()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LogOut()
        {
            
            return RedirectToAction("Index","Home");
        }
        


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
