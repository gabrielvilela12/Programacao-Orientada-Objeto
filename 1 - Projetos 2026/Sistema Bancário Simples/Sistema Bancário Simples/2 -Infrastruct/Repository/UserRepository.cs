using Microsoft.EntityFrameworkCore;
using Sistema_Bancário_Simples.Application.ViewModel;
using Sistema_Bancário_Simples.Domain.Entities;
using Sistema_Bancário_Simples.Presentation;
using Sistema_Bancário_Simples.Presentation.View;


namespace Sistema_Bancário_Simples
{
    public class UserRepository(ApplicationDbContext _context)
    {
        readonly ApplicationDbContext context = _context;

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public UserViewModel? LoginUser(User user)
        {
            bool isCorrectPassword;
            var existingUser = new User();

            existingUser = context.Users
                .FirstOrDefault(u => u.Email == user.Email.ToLower());

            if (existingUser == null) return null;

            isCorrectPassword = BCrypt.Net.BCrypt.Verify(user.PasswordHash, existingUser?.PasswordHash ?? "");

            if (isCorrectPassword)
            {
                return new UserViewModel
                {
                    Id = existingUser.Id,
                    Name = existingUser.Name,
                    Email = existingUser.Email,
                    Balance = existingUser.Balance
                };
            }

            return null;

        }

        public bool UserExists(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public void AddAmount(int userId, decimal amount)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.Balance += amount;
                context.SaveChanges();
            }
        }

        public decimal GetUserBalance(int userId)
        {
            var user = context.Users.Find(userId);
            return user?.Balance ?? 0;
        }

        public void SubtractAmount(int userId, decimal amount)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.Balance -= amount;
                context.SaveChanges();
            }
        }

        public void AddTransferenceRecord(int idLoged, int idTranference,decimal transferAmount)
        {
            context.PaymentHistories.Add(new PaymentHistory
            {
                UserLogedId = idLoged,
                UserTransferenceId = idTranference,
                transferAmount = transferAmount,
                PaymentDate = DateTime.UtcNow
            });

            context.SaveChanges();
        }

        public List<UserTransferenceViewModel> FetchAllUsers()
        {
            var userList = context.Users.ToList();

            var userViewModelList = userList.Select(user => new UserTransferenceViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }).ToList();

            return userViewModelList;


        }

        public int FetchUser(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                return user.Id;

            }

            return -1;
        }

        public List<TransferenceViewModel> GetTransactionHistory(int userId)
        {
            var transactions = context.PaymentHistories.Where(u => u.UserLogedId == userId).ToList();

            return transactions.Select(t => new TransferenceViewModel
            {
                Id = t.Id,
                Amount = t.transferAmount,
                Date = t.PaymentDate,
                Sender = new UserViewModel
                {
                    Id = t.UserLogedId,
                    Name = context.Users.Find(t.UserLogedId)?.Name ?? "",
                    Email = context.Users.Find(t.UserLogedId)?.Email ?? ""
                },
                Receiver = new UserTransferenceViewModel
                {
                    Id = t.UserTransferenceId,
                    Name = context.Users.Find(t.UserTransferenceId)?.Name ?? "",
                    Email = context.Users.Find(t.UserTransferenceId)?.Email ?? ""
                }
            }).ToList();





        }



    }
}

