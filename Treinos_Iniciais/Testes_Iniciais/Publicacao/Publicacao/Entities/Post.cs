using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacao
{
    internal class Post
    {
        public DateTime Moment { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public Post() { }

        public Post(DateTime moment, string title, string content, int likes)
        {
            Moment = moment;
            Title = title;
            Content = content;
            Likes = likes;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }

        // Sobrescrevendo o método ToString para retornar a representação do post
        public override string ToString()
        {
            // Utiliza a classe StringBuilder para construir o texto de maneira eficiente
            StringBuilder sb = new StringBuilder();

            // Adiciona o título do post
            sb.AppendLine(Title);

            // Adiciona a quantidade de likes
            sb.Append(Likes);
            sb.Append(" Likes - ");

            // Adiciona a data e hora do post formatada
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));

            // Adiciona o conteúdo do post
            sb.AppendLine(Content);

            // Adiciona o cabeçalho "Comments:" para os comentários
            sb.Append("Comments: ");

            // Itera por cada comentário no post e adiciona o texto do comentário ao StringBuilder
            foreach (Comment c in Comments)
            {
                sb.AppendLine(c.Text);  // Adiciona o texto do comentário
            }
            // Retorna a string completa construída
            return sb.ToString();

        }
    }
}
