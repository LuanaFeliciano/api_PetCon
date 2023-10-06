using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ClienteContext
{
    public class Cliente : User
    {
        public string Senha { get; set; }
        public int Telefone { get; set; }
<<<<<<< HEAD
        
=======

>>>>>>> 120f2ce0865a7a98f48afdcfd895c7d311b3c29d

        [JsonIgnore]
        public List<Animal>? Animais { get; set; }


        public int ClinicaId { get; set; } // Propriedade que representa a associação à clínica

        [JsonIgnore]
        public Clinica? Clinica { get; set; } // Propriedade de navegação para a clínica associada
    }
}
