using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabelGPWebAPI.Data;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Extensions;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Controllers
{
    [Authorize]
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult> Save(ICollection<EmployeeDto> employeeDtos)
        {
            var username = User.GetUsername();
            return Ok(await _employeesRepository.SaveEmployeesByUsernameAsync(employeeDtos, username));
        }
        
        [HttpGet]
        public async Task<ActionResult<ICollection<EmployeeDto>>> GetEmployees()
        {
            var username = User.GetUsername();
            return Ok(await _employeesRepository.GetEmployeesByUsernameAsync(username));
        }
    }
}