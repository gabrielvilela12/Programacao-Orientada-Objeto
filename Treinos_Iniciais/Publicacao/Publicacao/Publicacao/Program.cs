using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacao
{
    // Classe principal do programa
    internal class Program
    {
        // Método principal que será executado quando o programa rodar
        static void Main(string[] args)
        {
            // Criação de dois objetos Comment (comentários) associados a um post
            Comment c1 = new Comment("Have a nice trip!");
            Comment c2 = new Comment("Wow that's awesome!");

            // Criação de um objeto Post com data, título, conteúdo e quantidade de likes
            Post p1 = new Post(
                DateTime.Parse("21/06/2018 13:05:44"), // Data e hora do post
                "Traveling to New Zealand",            // Título do post
                "I'm going to visit this wonderful country!", // Conteúdo do post
                12);                                   // Quantidade de likes

            // Adiciona os comentários criados anteriormente ao primeiro post
            p1.AddComment(c1);
            p1.AddComment(c2);

            // Criação de dois novos comentários para o segundo post
            Comment c3 = new Comment("Good night");
            Comment c4 = new Comment("May the Force be with you");

            // Criação de um segundo post com data, título, conteúdo e quantidade de likes
            Post p2 = new Post(
                DateTime.Parse("28/07/2018 23:14:19"),
                "Good night guys",
                "See you tomorrow",
                5);

            // Adiciona os comentários ao segundo post
            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.ReadLine();
        }

        
        
    }
}

