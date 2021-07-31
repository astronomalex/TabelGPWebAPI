using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabelGPWebAPI.DTOs;
using TabelGPWebAPI.Entities;
using TabelGPWebAPI.interfaces;

namespace TabelGPWebAPI.Data
{
    public class ShiftsRepository : IShiftsRepository
    {
        private readonly ApplicationContext _context;

        public ShiftsRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public async Task<ICollection<ShiftDto>> GetShiftsByUsername(string username)
        {
            var user = await GetUser(username);
            var shiftsByUser = _context.Shifts
                .Include(s => s.Machine)
                .Include(s => s.EmployeeTimes)
                .ThenInclude(e => e.Employee)
                .Where(s => s.AppUserId == user.Id);
            ICollection<ShiftDto> shiftDtos = new List<ShiftDto>();
            foreach (var shift in shiftsByUser)
            {
                ICollection<EmployeeTimeDto> employeeTimeDtos = new List<EmployeeTimeDto>();

                foreach (var shiftEmployeeTime in shift.EmployeeTimes)
                {
                    employeeTimeDtos.Add(new EmployeeTimeDto
                    {
                        DoublePayTime = shiftEmployeeTime.DoublePayTime,
                        Grade = shiftEmployeeTime.Grade,
                        NightTime = shiftEmployeeTime.NightTime,
                        PprTime = shiftEmployeeTime.PprTime,
                        PrikTime = shiftEmployeeTime.PrikTime,
                        ProstTime = shiftEmployeeTime.ProstTime,
                        SdelTime = shiftEmployeeTime.SdelTime,
                        SrednTime = shiftEmployeeTime.SrednTime,
                        TbNum = shiftEmployeeTime.Employee.TabelNum
                    });
                }


                var shiftDto = new ShiftDto
                {
                    Mashine = shift.Machine.MachineName,
                    DateSmen = shift.DateShift.Year + "-" + shift.DateShift.Month + "-" + shift.DateShift.Day,
                    NumSmen = shift.NumShift,
                    WorkersTime = employeeTimeDtos
                };
                
                shiftDtos.Add(shiftDto);
            }

            return shiftDtos;
        }

        public async Task<int> SaveShiftsAsync(ICollection<ShiftDto> shiftDtos, string username)
        {
            var user = await GetUser(username);
            var shiftsByUser = _context.Shifts.Where(s => s.AppUser == user);
            foreach (var shift in shiftsByUser)
            {
                _context.Shifts.Remove(shift);
            }

            foreach (var sDto in shiftDtos)
            {
                var employeeTimes = new List<EmployeeTime>();
                foreach (var employeeTimeDto in sDto.WorkersTime)
                {
                    var employeeTime = new EmployeeTime
                    {
                        DoublePayTime = employeeTimeDto.DoublePayTime,
                        NightTime = employeeTimeDto.NightTime,
                        PprTime = employeeTimeDto.PprTime,
                        PrikTime = employeeTimeDto.PrikTime,
                        ProstTime = employeeTimeDto.ProstTime,
                        SdelTime = employeeTimeDto.SdelTime,
                        SrednTime = employeeTimeDto.SrednTime,
                        EmployeeId = _context.Employees.First(e => e.TabelNum == employeeTimeDto.TbNum).Id,
                        Employee = _context.Employees.First(e => e.TabelNum == employeeTimeDto.TbNum),
                        Grade = employeeTimeDto.Grade

                    };
                    employeeTimes.Add(employeeTime);
                    await _context.EmployeeTimes.AddAsync(employeeTime);
                }

                var machine = _context.Machines.FirstOrDefault(m => m.MachineName == sDto.Mashine);
                if ( machine == null)
                {
                    machine = new Machine
                    {
                        MachineName = sDto.Mashine
                    };
                    await _context.Machines.AddAsync(machine);
                }

                var shift = new Shift
                {
                    DateShift = DateTime.Parse(sDto.DateSmen),
                    AppUser = user,
                    AppUserId = user.Id,
                    Machine = machine,
                    NumShift = sDto.NumSmen,
                    EmployeeTimes = employeeTimes
                };
                var result = await _context.Shifts.AddAsync(shift);
                Console.WriteLine(result);
                await _context.SaveChangesAsync();
            } 
            
            return await _context.SaveChangesAsync();
        }
        
        private async Task<AppUser> GetUser(string username)
        {
            
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);;
        }
    }
    
}