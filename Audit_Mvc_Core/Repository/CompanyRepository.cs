using Microsoft.EntityFrameworkCore;
using Audit_Mvc_Core.Models;
using Audit_Mvc_Core.Repository;

namespace Audit_Mvc_Core.Repository
{
    public class CompanyRepository:ICompanyRepository
    {
        private readonly AuditContext _Context;

        public CompanyRepository(AuditContext auditContext)
        {
            _Context = auditContext;
        }

        public async Task<List<Company>> GetCompanies()
        {
            if (_Context != null)
            {
                return await _Context.Companies.ToListAsync();
            }
            return null;
        }
        public async Task<Company> CompanyRegistration(Company cmp)
        {
            if (_Context != null)
            {
                var reg=await _Context.Companies.AddAsync(cmp);
                await _Context.SaveChangesAsync();
                return reg.Entity;
            }
            return null;
        }
    }
}
