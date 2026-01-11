using GerenciadorUsuariosAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorUsuariosAPI.Data
{
    /// <summary>
    /// Banco de dados em memória para armazenar usuários temporariamente.
    /// </summary>
    public static class InMemoryDatabase
    {
        /// <summary>
        /// Lista principal de usuários mockados.
        /// </summary>
        private static readonly List<User> l_users = new List<User>();

        /// <summary>
        /// Contador para gerar IDs automáticos para novos usuários.
        /// </summary>
        private static int i_nextId = 1;

        /// <summary>
        /// Retorna todos os usuários cadastrados na memória.
        /// </summary>
        /// <returns>Lista de todos os usuários.</returns>
        public static List<User> GetAll()
        {
            return l_users;
        }

        /// <summary>
        /// Busca um usuário pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser buscado.</param>
        /// <returns>Usuário encontrado ou null caso não exista.</returns>
        public static User? GetById(int id)
        {
            return l_users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Busca um usuário pelo seu nome de usuário (case-insensitive).
        /// </summary>
        /// <param name="username">Nome do usuário a ser buscado.</param>
        /// <returns>Usuário encontrado ou null caso não exista.</returns>
        public static User? GetByUsername(string username)
        {
            return l_users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Adiciona um novo usuário à lista, atribuindo um ID automático.
        /// </summary>
        /// <param name="user">Usuário a ser adicionado.</param>
        public static void Add(User user)
        {
            user.Id = i_nextId++; // Atualiza ID para o próximo
            l_users.Add(user);
        }

        /// <summary>
        /// Remove um usuário da lista pelo seu ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        public static void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                l_users.Remove(user);
            }
        }
    }
}
