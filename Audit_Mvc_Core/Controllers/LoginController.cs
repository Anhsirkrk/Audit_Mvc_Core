using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;
using Audit_Mvc_Core.ViewModel;


namespace Audit_Mvc_Core.Controllers
{
    public class LoginController : Controller
    {

        AuditContext _Context;
        
        ILoginRepository _ilr;

        public LoginController(AuditContext auditContext,ILoginRepository ilr)
        {
            _Context = auditContext;
            
            _ilr = ilr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var adminlog = await _ilr.AuthenticateAdminLog(lvm.username, lvm.password);
                if (adminlog != null)
                {
                    var adminid = adminlog.AdminId;
                    return RedirectToAction("Index", "Home", adminid);
                }
                else
                {
                    var emplog = await _ilr.AuthenticateEmployeeLog(lvm.username, lvm.password);
                    if (emplog != null)
                    {
                        var empid = emplog.EmpId;
                        TempData["eid"] = empid;
                        return RedirectToAction("Index", "Home", empid);
                    }
                    else
                    {
                        var custlog = await _ilr.AuthenticateCustomerLog(lvm.username, lvm.password);
                        if(custlog != null)
                        {
                            var Cid = custlog.CustomerId;
                            TempData["cid"] = Cid;
                           
                            return RedirectToAction("Index", "Home", Cid);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid Username or Password");
                        }
                    }
                }
            }
            return View(lvm);
        }
    }
}
