using DDD.Domain.ClienteContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        public string SenhaAcesso { get; set; }

        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; set; }

        [JsonIgnore]
        // Propriedade de navega��o para veterin�rios associados � cl�nica
        public List<Veterinario>? Veterinarios { get; set; }

        [JsonIgnore]
        public List<Cliente>? Clientes { get; set; }

        public Clinica()
        {
            DataCadastro = DateTime.Now; 
        }
    }

}
