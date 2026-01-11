using GK.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GK.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string SenhaHash { get; set; } = string.Empty;

        public PerfilUsuario Perfil { get; set; }
    }
}

