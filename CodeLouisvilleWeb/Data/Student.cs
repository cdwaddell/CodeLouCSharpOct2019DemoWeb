using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLouisvilleWeb.Data
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset? LastClassCompletedOn { get; set; }
    }
}
