using System;
using System.Collections.Generic;

namespace Comparar_Estudante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>(); //Cria uma lista para salvar o bloco e alunos da sala
            int contador = 0; //usado para definir as strings que serão mostradas

            for (int i = 0; i < 3; i++)
            {
                List<Student> pobj_Students = new List<Student>();

                Console.Write("How many students for Course ");
                switch (contador)
                {
                    case 0:
                        Console.Write("A: ");
                        break;
                    case 1:
                        Console.Write("B: ");
                        break;
                    case 2:
                        Console.Write("C: ");
                        break;
                }
                int amount = int.Parse(Console.ReadLine());

                for (int j = 0; j < amount; j++)
                {
                    Console.Write("Code member {0}: ", j + 1);
                    int member = int.Parse(Console.ReadLine());
                   
                    Student student = new Student(member);
                    if (pobj_Students.Contains(student)) //caso usuário já exista, ele não sera salvo
                    {
                        Console.WriteLine("Student is already in the room"); 
                        j--; //Usado para retornar o usuario até ser válido                 
                    }
                    else
                    {
                        pobj_Students.Add(student);
                    }
                }

                switch (contador)
                {
                    case 0:
                        courses.Add(new Course(Setores.A, pobj_Students));
                        break;
                    case 1:
                        courses.Add(new Course(Setores.B, pobj_Students));

                        break;
                    case 2:
                        courses.Add(new Course(Setores.C, pobj_Students));
                        break;
                }
                contador++;
            }

            HashSet<Student> Codigo_Students = new HashSet<Student>(); //Armazena os usuários uma unica vez

            //Exibe os usuários e a sala
            foreach (Course obj in courses)
            {
                Console.WriteLine("\nBloco: " + obj.Blocos);
                foreach (Student student in obj.Codigo_Student)
                {
                    Console.WriteLine(student);
                    Codigo_Students.Add(student);
                }
            }
            Console.WriteLine("Unique students  {0}", Codigo_Students.Count);
            Console.ReadLine();
        }
    }
}
