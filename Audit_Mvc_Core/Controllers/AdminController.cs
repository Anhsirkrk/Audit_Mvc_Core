using Microsoft.AspNetCore.Mvc;
using Audit_Mvc_Core.Models;
using Microsoft.CodeAnalysis.Operations;
using Audit_Mvc_Core.Repository;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace Audit_Mvc_Core.Controllers
{
    public class AdminController : Controller
    {
        ILoginRepository _ilr;
        IAdminRepository _iar;

        private readonly AuditContext _context;

        public AdminController(ILoginRepository ilr, AuditContext context,IAdminRepository iar)
        {
            _iar = iar;
            _ilr = ilr;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Admin_DashBoard()
        {
            ViewBag.CountofEmp=_iar.CountofEmployees().ToString();
            ViewBag.CountofCmp = _iar.CountofCompanies().ToString();
            ViewBag.CountofCust=_iar.CountofCustomers().ToString();
            return View();
        }

        //[HttpGet]
        //public IActionResult Admin_Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Admin_Login(Admin admin)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var logdetails = await _ilr.AuthenticateAdminLog(admin.AdminUsername, admin.AdminPassword);

        //        if (logdetails != null)
        //        {
        //            return RedirectToAction("Admin_Dashboard");
        //        }

        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid Username or Password");
        //        }
        //    }
        //    return View(admin);
        //}

        public async Task<IActionResult> AdminRegistration()
        {
            var adm = _context.Admins.OrderByDescending(x => x.AdminId).FirstOrDefault();
            ViewBag.AdminId = adm != null ? Convert.ToInt32(adm.AdminId) + 1 : 1;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminRegistration(Admin Ad)
        {
            if (ModelState.IsValid)
            {
                var item = await _iar.AdminRegistration(Ad);
                return RedirectToAction("Login","Login");
            }
            return View(Ad);
        }






        [HttpGet]
        public IActionResult AdminTaskAssign()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminTaskAssign(AdminTaskAssign ATA)
        {
                                            //from employeecontroller, employee details empid

            var eid = TempData["emps"].ToString();
            ViewBag.emp = eid;

                                            //from customer controller , customer details custid

            var cust = TempData["cust"].ToString();
            ViewBag.cust =cust;


            if (ModelState.IsValid) 
            {
                    await _iar.AdminTaskAssign(ATA);

            } 
            return View(ATA);  
        }



    }
}
