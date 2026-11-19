using Microsoft.EntityFrameworkCore;
using ProjectManagement_API.Core.Entities;
using ProjectManagement_API.Core.Interfaces;
using ProjectManagement_API.Infrastracture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Infrastracture.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            { return null; }
            email = email.Trim();

           var res= await _appDbContext.Employee.Where(x=>x.EmailAddress==email).Include(x=>x.Department).FirstOrDefaultAsync();
            return res;
        }
    }
}
