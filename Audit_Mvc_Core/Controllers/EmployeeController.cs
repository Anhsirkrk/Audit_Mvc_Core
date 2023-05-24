using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Audit_Mvc_Core.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AuditContext _Context;
        private readonly IEmployeeRepository _ier;

        public EmployeeController(AuditContext auditContext, IEmployeeRepository ier)
        {
            _Context = auditContext;
            _ier = ier;
        }

        public async Task<IActionResult> Index()
        {
            var index = await _Context.Employees.ToListAsync();
            
            return View(index);
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public async Task<IActionResult> EmpDetails(int? id)
        {
            if (id == null || _Context.Employees == null)
            {
                return NotFound();
            }
            var Employee = await _Context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            var Emp = Employee.EmpId;
            TempData["emps"] = Emp;
            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        public async Task<IActionResult> EmployeeRegistration()
        {
            var Cust = _Context.Employees.OrderByDescending(m => m.EmpId).ToList().FirstOrDefault();

            ViewBag.Id = Cust != null ? Convert.ToInt32(Cust.EmpId) + 1 : 1;

            

            //ViewBag.Id = Convert.ToInt32(Cust.EmpId+1);   
            if (Cust == null)
            {
                ViewBag.Id = 1;
            }
            else
            {
                ViewBag.Id = Convert.ToInt32(Cust.EmpId + 1);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeRegistration(Employee Emp)
        {
            if (ModelState.IsValid)
            {
                var item = await _ier.EmployeeRegistration(Emp);
                return RedirectToAction("Dashboard");
            }
            return View(Emp);
        }
         
        [HttpGet]
        public async Task<IActionResult> EmployeeEdit(int? id)
        {
            if (id == null || _Context == null)
            {
                return NotFound();
            }

            var employee = await _Context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeEdit(int id, Employee Emp)
        {
            if (id != Emp.EmpId)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                _Context.Update(Emp);
                await _Context.SaveChangesAsync();
            }
            return View(Emp);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cust = await _Context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);

            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(Employee emp)
        {
            if (_Context.Employees == null)
            {
                return Problem("dataset is not found");
            }
            var employee = await _Context.Employees.FindAsync(emp.EmpId);
            if (employee != null)
            {
                _Context.Employees.Remove(employee);
            }
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}
