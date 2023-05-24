using Audit_Mvc_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Audit_Mvc_Core.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AuditContext _context;
        ICustomerRepository _icr;

        public CustomerController(ICustomerRepository icr,AuditContext context)
        {
            _context = context;
            _icr = icr;
        }

        public async Task<IActionResult> Index()
        {
            var index= await _context.Customers.ToListAsync();
            return View(index);
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> CustDetails(int? id)
        {


            if (id == null ||_context.Customers==null)
            {
                return NotFound();
            }
            var customer= await _context.Customers.FirstOrDefaultAsync(x=>x.CustomerId==id);
            var cust = customer.CustomerId;
            TempData["cust"] = cust;

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }





 //Scaffold-DbContext "server=127.0.0.1;port=3306;user=root;password=Krishna@209;database=Audit" MySql.EntityFrameworkCore -OutputDir Models -Context AuditContext -Force



        public async Task<IActionResult> CustRegistration()
        {
            var Cust = _context.Customers.OrderByDescending(m=>m.CustomerId).ToList().FirstOrDefault();

            ViewBag.Id = Cust != null ? Convert.ToInt32(Cust.CustomerId + 1) : 1;
            

            //ViewBag.Id = Convert.ToInt32(Cust.CustomerId+1);
            if(Cust == null)
            {
                ViewBag.Id = 1;
            }
            else
            {
                ViewBag.Id = Convert.ToInt32(Cust.CustomerId + 1);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustRegistration(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var item = await _icr.CustomerRegistration(customer);
                return RedirectToAction("Dashboard");
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerEdit(int? id)
        {
            if (id == null || _context==null)
            {
                return NotFound();
            }

            var cust = await _context.Customers.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerEdit(int id, Customer cust)
        {
            if (id != cust.CustomerId)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                _context.Update(cust);
                await _context.SaveChangesAsync();
            }
            return View(cust);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cust=  await _context.Customers.FirstOrDefaultAsync(x=>x.CustomerId==id);

            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(Customer cust)
        {
            if (_context.Customers==null)
            {
                return Problem("dataset is not found");
            }
            var customer =await _context.Customers.FindAsync(cust.CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);    
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CustTaskcreation()
        {
            var cid = TempData["cid"].ToString();
            ViewBag.cid=cid;
            var companyid = _context.Companies.ToList();
            ViewBag.CompanyId=companyid;
            return View();
        }
        [HttpGet]
        public async Task<CustTaskCreation> CustTaskCreation(CustTaskCreation CTC)
        {
            if (ModelState.IsValid)
            {
                await _icr.CustomerTaskCreation(CTC);
                _context.Add(CTC);
                await _context.SaveChangesAsync();
                //return RedirectToAction("SubmittedTasks", "Customer");
                
            }
            return null;
        }


    }

}
