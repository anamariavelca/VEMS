using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities
{
    public class UserAnswer : BaseEntity
    {
        public Guid UserExamId { get; set; }
        public Guid OptionId { get; set; }
        public virtual UserExam UserExam { get; set; }
        public virtual Option Option { get; set; }
    }
}
