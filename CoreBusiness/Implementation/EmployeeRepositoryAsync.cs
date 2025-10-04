using CoreBusiness.Interfaces;
using Data.Context;
using Data.Models.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Implementation
{
    public class EmployeeRepositoryAsync : IEmployeeRepositoryAsync
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepositoryAsync(AppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            var employeeData = await _dbContext.Employees
                 .Select(x => new EmployeeViewModel
                 {
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Email = x.Email,
                     Phone = x.Phone,
                     Position = x.Position,
                     Department = x.Department
                 })
                 .AsNoTracking()
                .ToListAsync();

            if (employeeData is null)
            {
                return Enumerable.Empty<EmployeeViewModel>();
            }

            return employeeData;
        }
    }
}
