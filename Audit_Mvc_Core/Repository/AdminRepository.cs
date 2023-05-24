using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;

namespace Audit_Mvc_Core.Repository
{
    public class AdminRepository: IAdminRepository
    {
        private readonly AuditContext _context;

        public AdminRepository(AuditContext context)
        {
            _context = context;
        }

        public async Task<Admin> AdminRegistration(Admin Ad)
        {
            if (_context != null)
            {
                var reg = await _context.Admins.AddAsync(Ad);
                await _context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;
        }




        public int CountofCustomers()
        {
            var query = "select count(*) from Customer";
            

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                var result=cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }

        public int CountofEmployees()
        {
            var query = "select count(*) from Employee";

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText= query;
                cmd.CommandType= System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                var result=cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }


        public int CountofCompanies()
        {
            var query = "select count(*) from Company";

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                var result = cmd.ExecuteScalar();

                return Convert.ToInt32(result);
            }
        }
        public async Task<AdminTaskAssign> AdminTaskAssign(AdminTaskAssign ATA)
        {
            if (_context != null)
            {
                var reg=await _context.AddAsync(ATA);
               await _context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;

        }
    }
}
