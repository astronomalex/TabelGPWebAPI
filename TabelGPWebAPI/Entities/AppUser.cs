using System;
using System.Collections;
using System.Collections.Generic;

namespace TabelGPWebAPI.Entities
{
    public class AppUser
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Norma> NormsByUser { get; set; }
        public ICollection<Employee> EmployeesByUser { get; set; }
        public ICollection<Shift> ShiftsByUser { get; set; }
        
    }
}