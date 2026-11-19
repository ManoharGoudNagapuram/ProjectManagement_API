using ProjectManagement_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Interfaces
{
    public interface IEmployeeSearchRepository
    {
        Task<List<EmployeeSearchResponse>> SearchEmployees(
            string searchKey,
            string sortBy,
            string sortOrder,
            int pageNumber,
            int pageSize
            );
    }
}
