using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca
{
    class Livro
    {
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public bool Disponivel { get; set; } = true; // Indica se o livro está disponível para aluguel

        private static List<Livro> ListaLivros = new List<Livro>();

        public Livro()
        {
        }

        public Livro(string titulo, Autor autor)
        {
            Titulo = titulo;
            Autor = autor;
        }

        //Método responsável por Criar um novo Livro
        public void AdicionarLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o nome do autor: ");
            string nomeAutor = Console.ReadLine();

            Autor autor = new Autor().VerificaAutor(nomeAutor);
            if (autor != null)
            {
                Livro livro = new Livro(titulo, autor);
                ListaLivros.Add(livro);
                Console.WriteLine("Livro adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Autor não encontrado. Adicione o autor antes de adicionar o livro.");
            }
            Console.ReadLine();
        }

        //Método responsável por DELETAR um novo Livro
        public void DeletarLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string s_Titulo = Console.ReadLine();

            //Verifica na ListaLivros se existe um Título igual ao que a pessoa digitou e adiciona no OBJETO 
            Livro obj_Livro = ListaLivros.Find(l => l.Titulo.Equals(s_Titulo, StringComparison.OrdinalIgnoreCase));

            if (obj_Livro != null) //Se existir na Lista
            {
                ListaLivros.Remove(obj_Livro);
                Console.WriteLine("Livro ({0}) deletado com sucesso", obj_Livro.Titulo);
            }
        }

        //Informa na tela os dados dos livros dentro da ListaLivros
        public void VisualizarLivros()
        {
            Console.WriteLine("\nLISTA DE LIVROS");
            for (int i = 0; i < ListaLivros.Count; i++)
            {
                Livro livro = ListaLivros[i];
                string status = livro.Disponivel ? "Disponível" : "Alugado";
                Console.WriteLine("{0}° Título: {1} \nAutor: {2} \nStatus: {3}", i + 1, livro.Titulo, livro.Autor.Nome, status);
            }
            Console.ReadLine();
        }

        //Verifica se o livro digitado pelo CLIENTE está livre ou Alugado
        public Livro VerificaDisponibilidade(string tituloLivro)
        {
            foreach (var livro in ListaLivros)
            {
                if (livro.Titulo.Equals(tituloLivro, StringComparison.OrdinalIgnoreCase))
                {
                    return livro;
                }
            }
            return null; // Retorna null se o livro não for encontrado
        }
    }
}
