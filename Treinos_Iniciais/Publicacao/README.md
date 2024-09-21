# Projeto de Publicação

Este projeto é um sistema simples de publicação e comentários, desenvolvido em C#. O sistema permite criar e gerenciar posts com comentários associados. Cada post tem uma data, um título, um conteúdo e uma quantidade de likes. Comentários podem ser adicionados e removidos dos posts.

## Funcionalidades

1. **Criação de Posts:**
   - Adiciona um novo post com data, título, conteúdo e quantidade de likes.
   - Visualiza os posts existentes.

2. **Gerenciamento de Comentários:**
   - Adiciona comentários aos posts.
   - Remove comentários dos posts.

## Estrutura do Código

Programa Main

```csharp
﻿using System;
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


````
### Classe `Comment`

Representa um comentário com um texto.

```csharp
using System;

namespace Publicacao
{
    internal class Comment
    {
        public string Text { get; set; }
    
        public Comment() 
        {
        }

        public Comment(string text)
        {
            Text = text;
        }
    }
}
```
### Classe `Post`

Representa um Post com Moment, Title, Content, Likes, List Comments

```csharp
using System;
using System.Collections.Generic;
using System.Text;

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Title);
            sb.Append(Likes);
            sb.Append(" Likes - ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine(Content);
            sb.Append("Comments: ");
            foreach (Comment c in Comments)
            {
                sb.AppendLine(c.Text);
            }
            return sb.ToString();
        }
    }
}

```
### Classe `Comment`

Representa um Comment com um Text

```csharp
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicacao
{
    internal class Comment
    {
        public string Text { get; set; }
    
        public Comment() 
        {
        }

        public Comment(string text)
        {
            Text = text;
        }   
    }
}

