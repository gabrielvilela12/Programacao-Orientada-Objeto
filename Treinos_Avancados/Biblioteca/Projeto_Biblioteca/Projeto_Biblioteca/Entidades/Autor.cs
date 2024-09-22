using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca
{
    class Autor
    {
        public string Nome { get; set; }

        // Lista estática que armazena todos os autores. Será acessada pela classe Livro para verificar e associar autores aos livros.
        private static List<Autor> ListaAutores = new List<Autor>(); 

        public Autor()
        {

        }

        public Autor(string nome)
        {
            Nome = nome;
        }

       

        // Método para adicionar um autor
        public void AddAutor()
        {
            Console.Write("Digite o nome do Autor: ");
            string nome = Console.ReadLine();

            Autor autor = new Autor(nome);
            ListaAutores.Add(autor);

            Console.WriteLine("Autor {0} adicionado com sucesso", nome);
            Console.ReadLine();

        }

        // Método para informar na tela todos os Autores
        public void VisualizarAutores()
        {
            Console.WriteLine("\nNOME DOS AUTORES");
            for (int i = 0; i < ListaAutores.Count; i++)
            {
                Autor pobj_Autor = ListaAutores[i];
                Console.WriteLine("{0}° Nome: {1}", i + 1, pobj_Autor.Nome);
            }
            Console.ReadLine();
        }

        // Verifica se o nome enviado pelo Cliente é um autor já criado
        public Autor VerificaAutor(string nomeAutor)
        {
            foreach (var autor in ListaAutores)
            {
                if (autor.Nome.Equals(nomeAutor, StringComparison.OrdinalIgnoreCase))
                {
                    return autor; // Retorna o autor encontrado
                }
            }
            return null; // Retorna null se o autor não for encontrado
        }
    }
}
