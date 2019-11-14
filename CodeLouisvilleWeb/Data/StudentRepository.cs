using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeLouisvilleWeb.Data
{
    public class StudentRepository
    {
        private Dictionary<int, Student> Students { get; set; } 
            = new Dictionary<int, Student>();
        private List<Student> AllStudents => Students.Values.ToList();


        public void Add(Student student)
        {
            if (student.StudentId == null)
                throw new ArgumentNullException(nameof(student));

            Students.Add(student.StudentId.Value, student);
        }

        public Student Get(int studentId)
        {
            return Students[studentId];
        }
    }
}
