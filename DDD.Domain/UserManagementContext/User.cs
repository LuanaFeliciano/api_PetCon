using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.UserManagementContext
{
    public abstract class User
    {
        public int UserId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataCadastro { get; private set; }

        public bool Ativo { get; set; }
        public User()
        {
            DataCadastro = DateTime.Now;
        }
    }
}
