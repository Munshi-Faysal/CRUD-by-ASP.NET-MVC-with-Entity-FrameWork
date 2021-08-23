using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_in_ASP.NET.Models;

namespace CRUD_in_ASP.NET
{
    public class EmplyeeCRUDDbsController : Controller
    {
        private readonly EmployeeContext _context;

        public EmplyeeCRUDDbsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: EmplyeeCRUDDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: EmplyeeCRUDDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplyeeCRUDDb = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplyeeCRUDDb == null)
            {
                return NotFound();
            }

            return View(emplyeeCRUDDb);
        }

        // GET: EmplyeeCRUDDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmplyeeCRUDDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EmpCode,Position")] EmplyeeCRUDDb emplyeeCRUDDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emplyeeCRUDDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emplyeeCRUDDb);
        }

        // GET: EmplyeeCRUDDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplyeeCRUDDb = await _context.Employees.FindAsync(id);
            if (emplyeeCRUDDb == null)
            {
                return NotFound();
            }
            return View(emplyeeCRUDDb);
        }

        // POST: EmplyeeCRUDDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EmpCode,Position")] EmplyeeCRUDDb emplyeeCRUDDb)
        {
            if (id != emplyeeCRUDDb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emplyeeCRUDDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplyeeCRUDDbExists(emplyeeCRUDDb.Id))
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
            return View(emplyeeCRUDDb);
        }

        // GET: EmplyeeCRUDDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplyeeCRUDDb = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplyeeCRUDDb == null)
            {
                return NotFound();
            }

            return View(emplyeeCRUDDb);
        }

        // POST: EmplyeeCRUDDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emplyeeCRUDDb = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(emplyeeCRUDDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplyeeCRUDDbExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
