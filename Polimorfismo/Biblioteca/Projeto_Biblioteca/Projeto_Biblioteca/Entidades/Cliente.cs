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

        //Método responsável por criar ADICIONAR um novo CLIENTE no sistema
        public void AdicionarCliente()
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

        // Método responsável por ALUGAR um livro
        public void AlugarLivro()
        {
            // Solicita o nome do cliente que deseja alugar o livro
            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            // Verifica na "ListaClientes" se existe um cliente com o nome igual ao digitado (ignorando letras maiúsculas/minúsculas)
            Cliente obj_Cliente = ListaClientes.Find(c => c.Nome.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase));

            if (obj_Cliente != null) // Se o cliente for encontrado
            {
                // Cria uma nova instância de Livro para acessar seus métodos
                Livro obj_Livro = new Livro();

                // Exibe todos os livros disponíveis na biblioteca
                Console.WriteLine("LIVROS DISPONÍVEIS");
                obj_Livro.VisualizarLivros();

                // Solicita o nome do livro que o cliente deseja alugar
                Console.Write("Digite o nome do livro que deseja alugar: ");
                string s_livroAlugar = Console.ReadLine();

                // Verifica se o livro está disponível para aluguel
                Livro livroDisponivel = obj_Livro.VerificaDisponibilidade(s_livroAlugar);

                if (livroDisponivel != null) // Se o livro foi encontrado
                {
                    if (livroDisponivel.Disponivel) // Se o livro estiver disponível
                    {
                        livroDisponivel.Disponivel = false; // Marca o livro como alugado
                        LivrosAlugados.Add(s_livroAlugar); // Adiciona à lista de livros alugados pelo cliente
                        Console.WriteLine("Livro '{0}' alugado com sucesso por {1}.", s_livroAlugar, obj_Cliente.Nome);
                    }
                    else
                    {
                        // Exibe uma mensagem caso o livro já esteja alugado
                        Console.WriteLine("O livro já está alugado.");
                    }
                }
                else
                {
                    // Exibe uma mensagem caso o livro não seja encontrado
                    Console.WriteLine("Livro não encontrado.");
                }
            }
            else
            {
                // Exibe uma mensagem caso o cliente não seja encontrado
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        public void DevolverLivro()
        {
            // Aqui será o código para devolver um livro
            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            // Verifica na "ListaClientes" se existe um cliente com o nome igual ao digitado
            Cliente obj_Cliente = ListaClientes.Find(c => c.Nome.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase));

            if (obj_Cliente != null) // Se o cliente for encontrado
            {
                // Exibe a lista de livros alugados pelo cliente
                Console.WriteLine("Livros alugados:");
                foreach (string livro in LivrosAlugados)
                {
                    Console.WriteLine(livro);
                }

                // Solicita o nome do livro que o cliente deseja devolver
                Console.Write("Digite o nome do livro que deseja devolver: ");
                string s_livroDevolver = Console.ReadLine();

                // Verifica se o livro está na lista de livros alugados pelo cliente
                if (LivrosAlugados.Contains(s_livroDevolver))
                {
                    // Remove o livro da lista de livros alugados
                    LivrosAlugados.Remove(s_livroDevolver);

                    // Marca o livro como disponível novamente
                    Livro obj_Livro = new Livro();
                    Livro livroDevolvido = obj_Livro.VerificaDisponibilidade(s_livroDevolver);
                    if (livroDevolvido != null)
                    {
                        livroDevolvido.Disponivel = true; // Marca o livro como disponível
                        Console.WriteLine("Livro '{0}' devolvido com sucesso.", s_livroDevolver);
                    }
                }
                else
                {
                    // Exibe uma mensagem caso o livro não esteja alugado pelo cliente
                    Console.WriteLine("O livro não está na lista de livros alugados.");
                }
            }
            else
            {
                // Exibe uma mensagem caso o cliente não seja encontrado
                Console.WriteLine("Cliente não encontrado.");
            }
        }


        //Método usado para exbir os CLIENTES na tela
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
    }
}


