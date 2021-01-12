using System;
using System.Collections.Generic;

namespace TabelGPWebAPI.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }

        // public Role()
        // {
        //     Users = new List<User>();
        // }
    }
}