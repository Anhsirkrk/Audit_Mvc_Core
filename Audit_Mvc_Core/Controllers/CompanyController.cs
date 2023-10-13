using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;
using System.Runtime.CompilerServices;

namespace Audit_Mvc_Core.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AuditContext _Context;
        private readonly ICompanyRepository _icr;

        public CompanyController(AuditContext context, ICompanyRepository icr)
        {
            _Context = context;
            _icr = icr;
        }

        public IActionResult Index()
        {
            var index =  _Context.Companies.ToListAsync();
            return View(index);
        }

        public async Task<IActionResult> CompanyRegistration()
        {
            var cmp=_Context.Companies.OrderByDescending(x=>x.CmpId).FirstOrDefault();
            ViewBag.CmpId = cmp != null ? Convert.ToInt32(cmp.CmpId) + 1 : 1;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompanyRegistration(Company cmp)
        {
            if(ModelState.IsValid)
            {
                await _icr.CompanyRegistration(cmp);
                return RedirectToAction("Index");
            }
            return View(cmp);
        }

        public async Task<IActionResult> CompanyDetails(int? id)
        {
            if (id == null || _Context == null)
            {
                return NotFound();
            }
            var company = await _Context.Companies.FirstOrDefaultAsync(x => x.CmpId == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }
    }
}
