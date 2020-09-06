using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities
{
    public class ExamQuestion
    {
        public Guid ExamId { get; set; }
        public Guid QuestionId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Question Question { get; set; }
    }
}
