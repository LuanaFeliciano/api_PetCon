using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DDD.Domain.ClinicaContext
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public string DataConsulta { get; set; }

        public string Status { get; set; }

        public string? Descricao { get; set; }
        public int IdVeterinario { get; set; }
        public Veterinario? Veterinarios { get; set; }

        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
