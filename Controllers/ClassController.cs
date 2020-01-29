using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManageSchool.AspNetCore.NewDb.Models;

namespace ManageSchool.AspNetCore.NewDb.Controllers
{
    public class ClassController : Controller
    {
        private readonly SchoolContext _context;

        public ClassController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {

            // return View(await _context.Class.ToListAsync());
            return View(await _context.Class.ToListAsync());
        }

        // GET: Class/Details/5
        public async Task<Object> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .FirstOrDefaultAsync(m => m.ClassId.ToString() == id);
            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Object> Create([Bind("ClassId,ClassName,Location")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return @class;
        }

        //ADD: Class/Add
        public IActionResult Add()
        {

            return View();
        }
        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            id.ToString();
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ClassId,ClassName,Location")] Class @class)
        {
            if (id != @class.ClassId.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ClassId.ToString()))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@class);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            id.ToString();
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Class
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            id.ToString();
            var @class = await _context.Class.FindAsync(id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(string id)
        {
            return _context.Class.Any(e => e.ClassId.ToString() == id);
        }
    }
}
