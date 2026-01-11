using Sistema_Bancário_Simples.Application;
using Sistema_Bancário_Simples.Application.Helpers;
namespace Sistema_Bancário_Simples.Presentation.View

{
    public class UserLogged(UserViewModel userLoged)
    {
        UserService _userService = new UserService(new UserRepository(new ApplicationDbContext()));
        FuncGeral _funcGeral = new FuncGeral();

        public void Show()
        {
            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Tela do Usuário ===");
                Console.WriteLine("1 - Ver saldo");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Ver histórico de transações");
                Console.WriteLine("6 - Sair");

                do
                {
                    opc = _funcGeral.GetInt("\nEscolha uma opção: ");
                    if (opc < 1 || opc > 6)
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                } while (opc < 1 || opc > 6);



                Console.Clear();
                switch (opc)
                {
                    case 1:
                        decimal balance = _userService.GetBalance(userLoged.Id);
                        Console.WriteLine($"Seu saldo é: R$ {balance}");
                        break;
                    case 2:
                        decimal depositAmount = _funcGeral.GetDecimal("Digite o valor a ser depositado: R$ ");
                        _userService.AddAmount(userLoged.Id, depositAmount);

                        break;

                    case 3:
                        decimal withdrawAmount = _funcGeral.GetDecimal("Digite o valor a ser sacado: R$ ");

                        bool success = _userService.WithdrawAmount(userLoged.Id, withdrawAmount);

                        if (success)
                        {
                            Console.WriteLine("Saque realizado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para o saque.");
                        }
                        break;

                    case 4:

                        Console.WriteLine("Lista de Emails cadastrados:\n");
                        var users = _userService.FetchAllUsers();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        foreach (var user in users)
                        {
                            if (user.Email != userLoged.Email)
                            {
                                Console.WriteLine($"- {user.Email}");
                            }
                        }
                        Console.ResetColor();
                        string recipientEmail = _funcGeral.GetString("\nDigite o email do destinatário: ");

                        decimal transferAmount = _funcGeral.GetDecimal("Digite o valor a ser transferido: R$ ");

                        bool transferSuccess = _userService.TransferAmount(userLoged.Id, recipientEmail, transferAmount);

                        if (transferSuccess)
                        {
                            Console.WriteLine("Transferência realizada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Falha na transferência. Verifique o saldo ou o email do destinatário.");
                        }

                        break;

                    case 5:
                        var transactions = _userService.GetTransactionHistory(userLoged.Id);
                        Console.WriteLine("Histórico de Transações:\n");
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"Para: {transaction.Receiver.Name} | Valor: R$ {transaction.Amount} | Data: {transaction.Date}");
                        }
                        break;
                }
                Console.ReadLine();

            } while (opc != 6);
        }
       


    }
}

