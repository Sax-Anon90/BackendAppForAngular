using CoreBusiness.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiForAngular.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepositoryAsync _employeeRepositoryAsync;
        public EmployeeController(IEmployeeRepositoryAsync _employeeRepositoryAsync)
        {
            this._employeeRepositoryAsync = _employeeRepositoryAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return Ok(await _employeeRepositoryAsync.GetAllEmployees());
        }
    }
}
