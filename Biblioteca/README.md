# Projeto de Gestão de Biblioteca

Este projeto é um sistema de gerenciamento de biblioteca desenvolvido em C# que permite a administração e gestão de livros, autores e clientes. O sistema inclui funcionalidades para adicionar, visualizar, alugar e devolver livros, além de adicionar e visualizar clientes e autores.
# (Incompleto e muito a melhorar)
Projeto estava sendo desenvolvido tranquilamente ate que fiquei alguns dias sem mexer e não comentei o suficiente ai então acabei me perdendo e acredito que tenha decaido pro final.
## Funcionalidades

1. **Modo Cliente:**
   - **Alugar Livros:**
     - Visualiza a lista de livros disponíveis.
     - Permite ao cliente alugar um livro se ele estiver disponível.
   - **Devolver Livros:**
     - Permite ao cliente devolver um livro alugado (a ser implementado).
   - **Criar Cliente:**
     - Adiciona um novo cliente à lista.
   - **Visualizar Clientes:**
     - Exibe a lista de todos os clientes cadastrados.

2. **Modo Administrador:**
   - **Adicionar Livros:**
     - Adiciona novos livros à biblioteca, associando-os a um autor.
   - **Adicionar Autores:**
     - Adiciona novos autores ao sistema.
   - **Visualizar Livros:**
     - Exibe a lista de todos os livros na biblioteca.
   - **Visualizar Autores:**
     - Exibe a lista de todos os autores cadastrados.
   - **Deletar Livros:**
     - Remove livros da biblioteca (funcionalidade a ser implementada).

## Estrutura do Código

### Classe `Cliente`

Representa um cliente com Nome e Data de Nascimento

```csharp
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca
{
    class Cliente
    {
        private static List<Cliente> ListaClientes = new List<Cliente>();
        private static List<string> LivrosAlugados = new List<string>(); // Para registrar os livros alugados pelo cliente

        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, DateTime dt_Nascimento)
        {
            Nome = nome;
            Dt_Nascimento = dt_Nascimento;
        }

        // Adiciona um novo cliente à lista
        public void AddCliente()
        {
            string s_valida = "nao";
            do
            {
                Console.Write("Nome do Cliente: ");
                string nomeCliente = Console.ReadLine();

                Console.Write("Data de nascimento (DD/MM/YYYY): ");
                DateTime dtCliente = DateTime.Parse(Console.ReadLine());

                Cliente NovoCliente = new Cliente(nomeCliente, dtCliente);
                ListaClientes.Add(NovoCliente);

                Console.Write("Gostaria de adicionar outro Cliente: ");
                s_valida = Console.ReadLine();

            } while (s_valida.ToUpper() == "SIM");
        }

        // Exibe a lista de clientes cadastrados
        public void VisualizarCliente()
        {
            if (ListaClientes.Count > 0)
            {
                for (int i = 0; i < ListaClientes.Count; i++)
                {
                    Cliente obj_Cliente = ListaClientes[i];

                    Console.WriteLine("\n---------------------------------------");
                    Console.WriteLine("Nome do Cliente: {0}", obj_Cliente.Nome);
                    Console.WriteLine("Data de Nascimento: {0}", obj_Cliente.Dt_Nascimento);
                    Console.WriteLine("---------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Não existe cliente, por favor adicione um.");
            }
            Console.ReadLine();
        }

        // Permite ao cliente alugar um livro
        public void AlugarLivro()
        {
            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Cliente cliente = ListaClientes.Find(c => c.Nome.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                Livro obj_Livro = new Livro();

                Console.WriteLine("LIVROS DISPONIVEIS");
                obj_Livro.VisualizarLivros();

                Console.Write("Digite o nome do livro que deseja alugar: ");
                string nomeLivro = Console.ReadLine();

                Livro livro = obj_Livro.VerificaDisponibilidade(nomeLivro);

                if (livro != null)
                {
                    if (livro.Disponivel)
                    {
                        livro.Disponivel = false; // Marca o livro como alugado
                        LivrosAlugados.Add(nomeLivro); // Adiciona à lista de livros alugados pelo cliente
                        Console.WriteLine("Livro '{0}' alugado com sucesso por {1}.", nomeLivro, cliente.Nome);
                    }
                    else
                    {
                        Console.WriteLine("O livro já está alugado.");
                    }
                }
            }
        }
    }
}

```
### Classe `Livro`
Representa um Livro com Titulo, Autor e Disponibilidade
```csharp
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

        public void DeletarLivro()
        {
            Console.Write("Digite o nome do livro: ");
            string s_Titulo = Console.ReadLine();

            Livro obj_Livro = ListaLivros.Find(l => l.Titulo.Equals(s_Titulo, StringComparison.OrdinalIgnoreCase));

            if (obj_Livro != null)
            {
                ListaLivros.Remove(obj_Livro);
                Console.WriteLine("Livro ({0}) deletado com sucesso", obj_Livro.Titulo);
            }
        }

        public void VisualizarLivros()
        {
            Console.WriteLine("\nLISTA DE LIVROS");
            for (int i = 0; i < ListaLivros.Count; i++)
            {
                Livro livro = ListaLivros[i];
                string status = livro.Disponivel ? "Disponível" : "Alugado";
                Console.WriteLine("{0}° Título: {1}, Autor: {2}, Status: {3}", i + 1, livro.Titulo, livro.Autor.Nome, status);
            }
            Console.ReadLine();
        }

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

```

### Classe `Autor`

Representa um autor com Nome

```csharp
using System;
using System.Collections.Generic;

namespace Projeto_Biblioteca
{
    class Autor
    {
        public string Nome { get; set; }

        private static List<Autor> ListaAutores = new List<Autor>();

        public Autor()
        {
        }

        public Autor(string nome)
        {
            Nome = nome;
        }

        // Adiciona um novo autor à lista
        public void AddAutor()
        {
            Console.Write("Digite o nome do Autor: ");
            string nome = Console.ReadLine();

            Autor autor = new Autor(nome);
            ListaAutores.Add(autor);

            Console.WriteLine("Autor {0} adicionado com sucesso", nome);
            Console.ReadLine();
        }

        // Exibe a lista de autores cadastrados
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

        // Verifica se um autor existe na lista
        public Autor VerificaAutor(string nomeAutor)
        {
            foreach (var autor in ListaAutores)
            {
                if (autor.Nome.Equals(nomeAutor, StringComparison.OrdinalIgnoreCase))
                {
                    return autor;
                }
            }
            return null;
        }
    }
}

