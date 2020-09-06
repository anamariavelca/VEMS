using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public int RatePolicyType { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
