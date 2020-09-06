using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities
{
    public class Exam : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
