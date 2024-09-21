using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                
                Console.Clear();
                Console.WriteLine("Bem vindo a nossa biblioteca\n");

                Console.WriteLine("1. CLIENTE");
                Console.WriteLine("2. ADMINISTRADOR");
                Console.WriteLine("3. Sair\n");

                Console.Write("Digite sua opção: ");
                int escolha = int.Parse(Console.ReadLine());

                //---- MODO CLIENTE ----//
                switch (escolha)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Cliente obj_Cliente = new Cliente();

                            Console.WriteLine("\n1. Alugar livros");
                            Console.WriteLine("2. Devolver livros");
                            Console.WriteLine("3. Criar Cliente");
                            Console.WriteLine("4. Vizualizar Clientes");
                            Console.WriteLine("5. Voltar");

                            Console.Write("\nDigite sua opção: ");
                            escolha = int.Parse(Console.ReadLine());

                            switch (escolha)
                            {
                               case 1:
                                   obj_Cliente.AlugarLivro();
                                   break;
                               case 2:
                              //      obj_Cliente.AddCliente();
                                    break;
                                case 3:
                                    obj_Cliente.AdicionarCliente();
                                    break;
                                case 4:
                                    obj_Cliente.VisualizarCliente();
                                    break;

                                default:
                                    if (escolha != 5)
                                    {
                                        Console.WriteLine("Opção inválida. Tente novamente.");
                                    }
                                    break;
                            }
                        } while (escolha != 5);
                        break;

                    //---- MODO ADMINISTRADOR ----//
                    case 2:
                        do
                        {
                            Console.Clear();

                            Livro obj_Livro = new Livro();
                            Autor obj_Autor = new Autor();
                            
                            Console.WriteLine("1. Adicionar livros");
                            Console.WriteLine("2. Adicionar autores");
                            Console.WriteLine("3. Vizualizar livros");
                            Console.WriteLine("4. Vizualizar autores");
                            Console.WriteLine("5. Deletar livros");
                            Console.WriteLine("6. Voltar");

                            Console.Write("\nEscolha a sua opção: ");
                            escolha = int.Parse(Console.ReadLine());

                            switch (escolha)
                            {
                                case 1:
                                    obj_Livro.AdicionarLivro();
                                    break;

                                case 2:
                                    obj_Autor.AddAutor();
                                    break;

                                case 3:
                                    obj_Livro.VisualizarLivros();
                                    break;

                                case 4:
                                    obj_Autor.VisualizarAutores();
                                    break;

                                 case 5:
                                     obj_Livro.DeletarLivro();
                                     break;

                                default:
                                    if (escolha != 6)
                                    {
                                        Console.WriteLine("Opção inválida. Tente novamente.");
                                    }
                                    break;
                            }

                        } while (escolha != 6);

                    break; //Fecha o case do Switch que entra no Administrador
                }

            } while (true);





        }
    }
}
