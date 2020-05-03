using System;
using Domain.Validations;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }

        public Cliente(string nome, string sobreNome, string email)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            Validate(this, new ClienteValidator());
        }
       
    }
}