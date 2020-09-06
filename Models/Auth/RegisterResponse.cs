using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Auth
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
