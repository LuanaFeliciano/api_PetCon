using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Clinica
    {
        public int ClinicaId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UsuarioAcesso { get; private set; }

        [Required]
        public string SenhaAcesso { get; private set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}
