using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProjectManagement_API.Core.Interfaces;
using ProjectManagement_API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Infrastracture.Repositories
{
    public class EmployeeSearchRepository : IEmployeeSearchRepository
    {
        private readonly string _connectionString;
        public EmployeeSearchRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlDbConnection") ?? throw new InvalidOperationException("");
        }
        public async Task<List<EmployeeSearchResponse>> SearchEmployees(string searchKey, string sortBy, string sortOrder, int pageNumber, int pageSize)
        {
            await using var connection=new SqlConnection(_connectionString);

            var parameters= new
            {
                SearchKey = searchKey,
                SortBy = sortBy,
                SortOrder = sortOrder,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var res = await connection.QueryAsync<EmployeeSearchResponse>("dbo.SearchEmployeesNew", parameters, commandType: System.Data.CommandType.StoredProcedure);

           return res.ToList();
        }
    }
}
