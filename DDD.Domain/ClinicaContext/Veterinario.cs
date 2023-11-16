using DDD.Domain.ClienteContext;
using DDD.Domain.ClinicaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Veterinario : User
    {
        public int ClinicaId { get; set; } // Propriedade que representa a associação à clínica

        [JsonIgnore]
        public List<Animal>? Animais { get; set; }

        [JsonIgnore]
        public Clinica? Clinica { get; set; } // Propriedade de navegação para a clínica associada


        [JsonIgnore]
        public List<Consulta>? Consultas { get; set; }

    }
}
