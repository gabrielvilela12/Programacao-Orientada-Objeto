using Sistema_Bancário_Simples.Application.ViewModel;
using Sistema_Bancário_Simples.Domain.Entities;
using Sistema_Bancário_Simples.Presentation;
using System.Linq.Expressions;
using System.Net.Mail;
using static BCrypt.Net.BCrypt;

namespace Sistema_Bancário_Simples.Application
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public List<string> CreateUser(string name, string email, string password)
        {
            List<string> validator = Validator(name, email, password);

            if (validator.Count == 0)
            {
                var user = new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = HashPassword(password),
                    Balance = 0
                };

                _userRepository.AddUser(user);
                validator.Add(UserEnum.UserCreated.GetDescription());
            }

            return validator;
        }

        public (UserViewModel userViewModel, string Message) AuthenticateUser(string email, string password)
        {
            var user = new User
            {
                Email = email,
                PasswordHash = password
            };

            var userViewModel = _userRepository.LoginUser(user);

            if (userViewModel != null) return (userViewModel, UserEnum.UserCreated.GetDescription());

            return (null, UserEnum.LoginFailed.GetDescription());
        }

        public bool IsUserCreated(List<string> messages)
        {
            return messages.Contains(UserEnum.UserCreated.GetDescription());
        }

        public void AddAmount(int userId, decimal amount)
        {
            _userRepository.AddAmount(userId, amount);
        }

        public decimal GetBalance(int userId)
        {
            return _userRepository.GetUserBalance(userId);
        }

        public bool WithdrawAmount(int userId, decimal amount)
        {
            decimal currentBalance = _userRepository.GetUserBalance(userId);
            if (currentBalance >= amount)
            {
                _userRepository.SubtractAmount(userId, amount);
                return true;
            }
            return false;
        }

        public List<UserTransferenceViewModel> FetchAllUsers()
        {
            return _userRepository.FetchAllUsers();
        }

        public bool TransferAmount(int userLogedId, string recipientEmail, decimal transferAmount)
        {
            WithdrawAmount(userLogedId, transferAmount);

            int idUserTransfer = _userRepository.FetchUser(recipientEmail);

            if (idUserTransfer >= 0)
            {
                AddAmount(idUserTransfer, transferAmount);

                _userRepository.AddTransferenceRecord(userLogedId, idUserTransfer, transferAmount);
                return true;
            }

            return false;
        }

        public List<TransferenceViewModel> GetTransactionHistory(int userId)
        {

            var transactions = _userRepository.GetTransactionHistory(userId);
            
            foreach (var transaction in transactions)
            {
                transaction.Date = transaction.Date.ToLocalTime();
            }

            return transactions;
        }

        private List<string> Validator(string name, string email, string password)
        {
            List<string> errors = new();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                string[] vazias =
                {
                    string.IsNullOrWhiteSpace(name) ? "Nome" : null,
                    string.IsNullOrWhiteSpace(email) ? "Email" : null,
                    string.IsNullOrWhiteSpace(password) ? "Senha" : null
                };

                errors.Add(
                    "Os seguintes campos estão vazios: " +
                    string.Join(", ", vazias.Where(v => v != null))
                );

                return errors;
            }

            if (!MailAddress.TryCreate(email, out _))
            {
                errors.Add(UserEnum.InvalidEmail.GetDescription());
            }

            if (_userRepository.UserExists(email))
            {
                errors.Add(UserEnum.UserExists.GetDescription());
            }

            if (password.Length < 6)
            {
                errors.Add(UserEnum.WeakPassword.GetDescription());
            }

            return errors;
        }
    }
}
