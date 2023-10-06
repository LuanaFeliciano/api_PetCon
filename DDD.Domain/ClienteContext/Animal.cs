using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ClienteContext
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Tipo { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }

        public int ClienteId { get; set; } // Propriedade que representa a associação ao cliente

        [JsonIgnore]
        public Cliente? Clientes { get; set; } // Propriedade de navegação para o cliente associado
    }
}
