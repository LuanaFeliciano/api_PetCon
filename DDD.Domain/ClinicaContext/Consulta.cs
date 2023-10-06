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
        public DateTime DataConsulta { get; set; } 
        public string Observacoes { get; set; }
        public string Status { get; set; }
        public int IdVeterinario { get; set; }
        public List<Veterinario> Veterinarios { get; set; }

        //public int IdCliente { get; set; }
        //public Cliente Cliente { get; set; }

        //public int IdAnimal { get; set; }
        //public Animal Animal { get; set; }
    }
}
