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
    public class DepartmentRepository: BaseRepository<Department>, IDepartmentRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IEmployeeRepository _employeeRepository;
        public DepartmentRepository(AppDbContext appDbContext, IEmployeeRepository employeeRepository) :base(appDbContext) 
        {
                _appDbContext = appDbContext;
            _employeeRepository = employeeRepository;
        }

        public async Task<Department> GetDepartmentByUserEmailAsync(string email)
        {
           var result=await _employeeRepository.GetEmployeeByEmailAsync(email);
            if (result==null)
            {
                return null;
            }

           return result.Department;
        }
    }
}
