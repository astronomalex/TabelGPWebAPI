using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Data
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly ApplicationContext _context;

        public EmployeesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeDto>> GetEmployeesByUsernameAsync(string username)
        {
            AppUser user = await _context.Users.FirstAsync(appUser => appUser.UserName == username);
            if (user == null) return null;

            var employeesByUser = _context.Employees.Where(e => e.AppUserId == user.Id);
            ICollection<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (var employee in employeesByUser)
            {
                employeeDtos.Add(new EmployeeDto()
                {
                    TabelNum = employee.TabelNum,
                    Grade = employee.Grade,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Patronymic = employee.Patronymic
                });
            }

            return employeeDtos;
        }

        public async Task<int> SaveEmployeesByUsernameAsync(ICollection<EmployeeDto> employeeDtos, string username)
        {
            var user = await _context.Users.FirstAsync(u => u.UserName == username);
            var employeesByUser = _context.Employees.Where(e => e.AppUserId == user.Id);
            foreach (var employeeForDelete in employeesByUser)
            {
                _context.Employees.Remove(employeeForDelete);
            }

            foreach (var employeeDto in employeeDtos)
            {
                await _context.Employees.AddAsync(new Employee
                {
                    Grade = employeeDto.Grade,
                    AppUser = user,
                    AppUserId = user.Id,
                    Name = employeeDto.Name,
                    Surname = employeeDto.Surname,
                    Patronymic = employeeDto.Patronymic,
                    TabelNum = employeeDto.TabelNum
                });
            }

            return await _context.SaveChangesAsync();
        }
    }
}