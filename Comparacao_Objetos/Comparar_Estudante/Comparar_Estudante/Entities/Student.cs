using System.Globalization;

namespace Comparar_Estudante
{
    partial class Student
    {
        public int Codigo { get; set; }

        public Student(int codigo)
        {
            Codigo = codigo;
        }

        public override string ToString()
        {
            return Codigo.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }
            Student other = obj as Student;
            return Codigo.Equals(other.Codigo);
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }

    }
}
