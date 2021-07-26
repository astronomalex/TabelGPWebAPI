using System.Collections.Generic;
using System.Threading.Tasks;
using TabelGPWebAPI.DTOs;

namespace TabelGPWebAPI.interfaces
{
    public interface IEmployeesRepository
    {
        Task<ICollection<EmployeeDto>> GetEmployeesByUsernameAsync(string username);
        Task<int> SaveEmployeesByUsernameAsync(ICollection<EmployeeDto> employeeDtos, string username);
    }
}