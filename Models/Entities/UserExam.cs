using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEMS.API.Models.Identity;

namespace VEMS.API.Models.Entities
{
    public class UserExam : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }

        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Score { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
