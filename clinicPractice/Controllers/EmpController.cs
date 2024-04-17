using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinicPractice.Models;

namespace clinicPractice.Controllers
{
    public class EmpController : Controller
    {
        private readonly ClinicSysContext _context;

        public EmpController(ClinicSysContext context)
        {
            _context = context;
        }

        // GET: Emp
        public async Task<IActionResult> Index()
        {
              return _context.Member_EmployeeLists != null ? 
                          View(await _context.Member_EmployeeLists.ToListAsync()) :
                          Problem("Entity set 'ClinicSysContext.Member_EmployeeLists'  is null.");
        }

        // GET: Emp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member_EmployeeLists == null)
            {
                return NotFound();
            }

            var member_EmployeeList = await _context.Member_EmployeeLists
                .FirstOrDefaultAsync(m => m.Emp_ID == id);
            if (member_EmployeeList == null)
            {
                return NotFound();
            }

            return View(member_EmployeeList);
        }

        // GET: Emp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emp_ID,Staff_Number,Name,Gender,Blood_Type,National_ID,Address,Contact_Address,Phone,Birth_Date,Emp_Type,Department,Emp_Password,EmpPhoto,Quit,EmpMail")] Member_EmployeeList member_EmployeeList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member_EmployeeList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member_EmployeeList);
        }

        // GET: Emp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Member_EmployeeLists == null)
            {
                return NotFound();
            }

            var member_EmployeeList = await _context.Member_EmployeeLists.FindAsync(id);
            if (member_EmployeeList == null)
            {
                return NotFound();
            }
            return View(member_EmployeeList);
        }

        // POST: Emp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Emp_ID,Staff_Number,Name,Gender,Blood_Type,National_ID,Address,Contact_Address,Phone,Birth_Date,Emp_Type,Department,Emp_Password,EmpPhoto,Quit,EmpMail")] Member_EmployeeList member_EmployeeList)
        {
            if (id != member_EmployeeList.Emp_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member_EmployeeList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Member_EmployeeListExists(member_EmployeeList.Emp_ID))
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
            return View(member_EmployeeList);
        }

        // GET: Emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member_EmployeeLists == null)
            {
                return NotFound();
            }

            var member_EmployeeList = await _context.Member_EmployeeLists
                .FirstOrDefaultAsync(m => m.Emp_ID == id);
            if (member_EmployeeList == null)
            {
                return NotFound();
            }

            return View(member_EmployeeList);
        }

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member_EmployeeLists == null)
            {
                return Problem("Entity set 'ClinicSysContext.Member_EmployeeLists'  is null.");
            }
            var member_EmployeeList = await _context.Member_EmployeeLists.FindAsync(id);
            if (member_EmployeeList != null)
            {
                _context.Member_EmployeeLists.Remove(member_EmployeeList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Member_EmployeeListExists(int id)
        {
          return (_context.Member_EmployeeLists?.Any(e => e.Emp_ID == id)).GetValueOrDefault();
        }
    }
}
