using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEMS.API.Models.Entities.Enums
{
    public enum StudentExamStatus
    {
        Enrolled = 1,
        InProgress = 2,
        FinishedPassed = 3,
        FinishedFailed = 4,
        FinishedOot = 5 //Finished out of time
    }
}
