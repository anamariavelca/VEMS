using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Models.Entities;

namespace VEMS.API.Models.Identity
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string Fullname { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
