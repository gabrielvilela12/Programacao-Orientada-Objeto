using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    class Aluno
    {
        //Atributos Privados
        private string Nome;
        private double Nota1 { get; set; }
        private double Nota2 { get; set; }
        private double Nota3 { get; set; }
        private double NotaFinal { get; set; }
        private string Classificacao { get; set; }

        //Construtor criado para receber as informações dada pelo Usuário e armazenar no Objeto 
        public Aluno(string nome, double nota1, double nota2, double nota3)
        {
            Nome = nome;
            Nota1 = nota1;
            Nota2 = nota2;
            Nota3 = nota3;
            SetNotas();
        }

        //Método responsável por Calcular a NotaFinal
        private void SetNotas()
        {
            NotaFinal = Nota1 + Nota2 + Nota3;
            GetClassificacao();
        }

        //Método responsável por Classsificar preencher a propriedade "Classificacao"
        private void GetClassificacao()
        {

            Classificacao = NotaFinal >= 60 ? "APROVADO" : "REPROVADO"; //se nota final for maior que 60 "APROVADO" se não "REPROVADO"
        }

        //Método
        public void ExibirAlunos(List<Aluno> ListaAlunos)
        {

            Console.WriteLine("\nNome: {0}", Nome);
            Console.WriteLine("1° Nota: {0}", Nota1);
            Console.WriteLine("2° Nota: {0}", Nota2);
            Console.WriteLine("3° Nota: {0}", Nota3);
            Console.WriteLine("Nota Total: {0}", NotaFinal);
            Console.Write("Aluno ");


            if (Classificacao == "REPROVADO")
            {
                Console.ForegroundColor = ConsoleColor.Red;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write(Classificacao);

            Console.ResetColor();
            Console.WriteLine("!");

            if (Classificacao == "REPROVADO")
            {
                Console.WriteLine("\nFaltou {0} pontos para {1} atingir a média", 60 - NotaFinal, Nome);
            }
        }

    }
}

