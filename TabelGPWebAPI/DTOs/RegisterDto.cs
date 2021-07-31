﻿using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TabelGPWebAPI.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}