using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparar_Estudante
{
    class Course
    {
        public Setores Blocos;
        public List<Student> Codigo_Student { get; set; }

        public Course()
        {

        }

        public Course(Setores blocos , List<Student> students) 
        {
            Blocos = blocos;
            Codigo_Student = students;
        }

        
    }
}
