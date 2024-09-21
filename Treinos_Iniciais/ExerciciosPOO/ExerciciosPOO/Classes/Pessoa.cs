using System;
using System.Collections.Generic;


namespace ExerciciosPOO
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public void ExibirInformacao(List<Pessoa> listaPessoas)
        {
            Console.WriteLine("\nDados das pessoas:");

            for (int i = 0; i < listaPessoas.Count; i++)
            {
                Console.WriteLine("\nNome: {0}", listaPessoas[i].Nome);
                Console.WriteLine("Idade: {0}", listaPessoas[i].Idade);
            }
        }

        public void ShowOlderPerson(Pessoa obj_Pessoa) //Exibir pessoa mais velha
        {
            Console.WriteLine("\nPESSOA MAIS VELHA:");
            Console.WriteLine("\nNome: {0}", obj_Pessoa.Nome);
            Console.WriteLine("Idade: {0}", obj_Pessoa.Idade);
        }

        public Pessoa SearchPerson(List<Pessoa> List_People)
        {
            Pessoa MaisVelha = new Pessoa();
            int IdadeMaior = 0;


            for (int i = 0; i < List_People.Count; i++)
            {
                Pessoa obj_Pessoa = List_People[i];

                if (obj_Pessoa.Idade > IdadeMaior)
                {
                    IdadeMaior = obj_Pessoa.Idade;
                    MaisVelha = obj_Pessoa;

                }
            }
            return MaisVelha;




        }

    }
}
