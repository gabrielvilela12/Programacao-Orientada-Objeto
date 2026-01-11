using GerenciadorUsuariosAPI.Data;
using GerenciadorUsuariosAPI.Models;
using GerenciadorUsuariosAPI.Models.DTOs;
using System;

namespace GerenciadorUsuariosAPI.Services
{
    /// <summary>
    /// Camada de serviço responsável por conter toda a lógica de negócios relacionada aos usuários.
    /// Essa camada abstrai o controlador e garante separação de responsabilidades (Controller -> Service -> Data).
    /// </summary>
    public class UsersServices
    {
        #region LISTAGEM

        /// <summary>
        /// Lista usuários aplicando filtros opcionais por nome e status de ativação.
        /// </summary>
        public List<UserResponseDto>? List(string? userName, bool? isActive)
        {
            var users = InMemoryDatabase.GetAll().ToList();

            // Filtro por nome de usuário (case insensitive)
            if (!string.IsNullOrEmpty(userName))
            {
                users = users.Where(u => u.Username.Contains(userName, StringComparison.OrdinalIgnoreCase)).ToList();
                if (!users.Any()) return null;
            }

            // Filtro por status de ativação (ativo/inativo)
            if (isActive.HasValue)
            {
                users = users.Where(u => u.IsActive == isActive.Value).ToList();
                if (!users.Any()) return null;
            }
            
            // Converte entidades para DTOs de resposta
            return users.Select(u => new UserResponseDto(u)).ToList();
        }

        #endregion

        #region REGISTRO

        /// <summary>
        /// Registra um novo usuário após validar senhas e duplicidade de nome.
        /// A senha é armazenada de forma segura usando hash com BCrypt.
        /// </summary>
        public UserResponseDto Register(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword) throw new Exception("As senhas estão diferentes.");

            if (InMemoryDatabase.GetByUsername(username) != null)
                throw new Exception("Este nome de usuário já está em uso.");

            // Gera hash seguro para senha
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            // Cria nova instância da entidade User
            var newUser = new User
            {
                Username = username,
                Password = passwordHash,
                IsActive = true
            };

            // Persiste o usuário no banco em memória
            InMemoryDatabase.Add(newUser);

            return new UserResponseDto(newUser);
        }

        #endregion

        #region LOGIN

        /// <summary>
        /// Autentica o usuário verificando username e senha criptografada.
        /// </summary>
        public UserResponseDto Login(string username, string password)
        {
            var user = InMemoryDatabase.GetByUsername(username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new Exception("Usuário ou senha inválidos.");

            if (!user.IsActive)
                throw new Exception("Conta desativada.");

            return new UserResponseDto(user);
        }

        #endregion

        #region ATIVAÇÃO / DESATIVAÇÃO

        /// <summary>
        /// Ativa um usuário existente após validação de credenciais de quem autoriza a ação.
        /// </summary>
        public UserResponseDto Activate(int id, AuthRequestDto authDto)
        {
            var authorizer = Authorize(authDto);

            var user = InMemoryDatabase.GetById(id)
                ?? throw new Exception("Usuário a ser ativado não foi encontrado.");

            user.IsActive = true;

            return new UserResponseDto(user);
        }

        /// <summary>
        /// Desativa um usuário existente após validação de credenciais de quem autoriza a ação.
        /// </summary>
        public UserResponseDto Deactivate(int id, AuthRequestDto authDto)
        {
            var authorizer = Authorize(authDto);

            var user = InMemoryDatabase.GetById(id) ?? throw new Exception("Usuário a ser desativado não foi encontrado.");

            user.IsActive = false;

            return new UserResponseDto(user);
        }

        #endregion

        #region EXCLUSÃO

        /// <summary>
        /// Exclui permanentemente um usuário após autorização e verificação de existência.
        /// </summary>
        public void Delete(int id, AuthRequestDto authDto)
        {
            var authorizer = Authorize(authDto);

            var user = InMemoryDatabase.GetById(id)
                ?? throw new Exception("Usuário a ser excluído não foi encontrado.");

            InMemoryDatabase.Delete(id);
        }

        #endregion

        #region AUTORIZAÇÃO PRIVADA

        /// <summary>
        /// Valida as credenciais de quem solicita uma ação sensível (ativar, desativar, deletar).
        /// </summary>
        private User Authorize(AuthRequestDto authDto)
        {
            var user = InMemoryDatabase.GetByUsername(authDto.Username)
                ?? throw new Exception("Usuário Nulo.");

            if (!BCrypt.Net.BCrypt.Verify(authDto.Password, user.Password))
                throw new Exception("senha inválida.");

            return user;
        }

        #endregion
    }
}
