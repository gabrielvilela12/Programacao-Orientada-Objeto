using Sistema_Bancário_Simples.Application;
using Sistema_Bancário_Simples.Presentation.View;
using Sistema_Bancário_Simples.Application.Helpers;

namespace Sistema_Bancário_Simples
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            UserService _userService = new UserService(new UserRepository(new ApplicationDbContext()));
            FuncGeral _funcGeral = new FuncGeral();
            string email, name, password;
            int result;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Bem-vindo ao Sistema Bancário Simples!");
                    Console.WriteLine("(1) Efetuar Login");
                    Console.WriteLine("(2) Criar Conta");
                    Console.Write("Digite uma opção: ");

                } while (!int.TryParse(Console.ReadLine(), out result) || (result != 1 && result != 2));

                Console.Clear();

                switch (result)
                {
                    case 1:
                        Console.WriteLine("Login selecionado.");

                        email = _funcGeral.GetString("Digite seu email: ");


                        password = _funcGeral.GetString("Digite sua senha: ");

                        var response = _userService.AuthenticateUser(email, password);

                        Console.WriteLine(response.Message);

                        if (response.userViewModel != null)
                        {
                            UserLogged userLogged = new UserLogged(response.userViewModel);
                            userLogged.Show();
                        }

                        Console.ReadLine();
                        break;

                    case 2:
                        bool isCreated;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Criar Conta selecionado.");

                            name = _funcGeral.GetString("Digite seu nome: ");

                            email = _funcGeral.GetString("Digite seu email: ");

                            password = _funcGeral.GetString("Digite sua senha: ");

                            List<string> mensagens = _userService.CreateUser(name, email, password);

                            foreach (var msg in mensagens)
                            {
                                Console.WriteLine("\n" + msg);
                            }

                            Console.ReadLine();

                            isCreated = _userService.IsUserCreated(mensagens);
                        } while (!isCreated);

                        break;
                }
            } while (true);
        }
    }
}

