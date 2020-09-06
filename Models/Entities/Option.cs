using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities
{
    public class Option : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Score { get; set; }
        public bool IsCorrect { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
