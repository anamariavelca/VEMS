using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Auth
{
    public class Register
    {
        [Required(ErrorMessage = "Please provide all mandatory fields")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide all mandatory fields")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please provide all mandatory fields")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide all mandatory fields")]
        public string Role { get; set; }
        public string Fullname { get; set; }
    }
}
