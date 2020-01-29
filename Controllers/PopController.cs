using System; using System.Collections.Generic; using System.Linq; using System.Threading.Tasks; using Microsoft.AspNetCore.Mvc; using Microsoft.AspNetCore.Mvc.Rendering; using Microsoft.EntityFrameworkCore; using ManageSchool.AspNetCore.NewDb.Models;  namespace ManageSchool.AspNetCore.NewDb.Controllers {     [Route("Pop")]     public class PopController : Controller     {         private readonly SchoolContext _context;          public PopController(SchoolContext context)         {             _context = context;         }

        // GET: Pop
        [HttpGet("{ClassId}")]         public async Task<IActionResult> Index(string classId)         {             if (classId == null)
            {
                NotFound();
            }             var schoolContext = await (from s in _context.Student                                        join c in _context.Class                                        on s.ClassId equals c.ClassId
                                       where c.ClassId.ToString() == classId
                                       select new DisplayStudent                                        {                                            StudentName = s.StudentName,                                            DateOfBirth = s.DateOfBirth,                                            GPA = s.GPA,                                            Email = s.Email,                                            ClassName = c.ClassName,

                                               }).ToListAsync();

            return View("Index", schoolContext);         }

        //// GET: Pop/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var displayStudent = await _context.Display
        //        .FirstOrDefaultAsync(m => m.ClassId == id);
        //    if (displayStudent == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(displayStudent);
        //}

        //// GET: Pop/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Pop/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ClassId,StudentName,DateOfBirth,GPA,Email,ClassName")] DisplayStudent displayStudent)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(displayStudent);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(displayStudent);
        //}

        //// GET: Pop/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var displayStudent = await _context.Display.FindAsync(id);
        //    if (displayStudent == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(displayStudent);
        //}

        //// POST: Pop/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("ClassId,StudentName,DateOfBirth,GPA,Email,ClassName")] DisplayStudent displayStudent)
        //{
        //    if (id != displayStudent.ClassId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(displayStudent);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DisplayStudentExists(displayStudent.ClassId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(displayStudent);
        //}

        //// GET: Pop/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var displayStudent = await _context.Display
        //        .FirstOrDefaultAsync(m => m.ClassId == id);
        //    if (displayStudent == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(displayStudent);
        //}

        //// POST: Pop/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var displayStudent = await _context.Display.FindAsync(id);
        //    _context.Display.Remove(displayStudent);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool DisplayStudentExists(string id)         {             return _context.Display.Any(e => e.ClassId.ToString() == id);         }     } }   