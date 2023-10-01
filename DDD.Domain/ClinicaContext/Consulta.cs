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
        public Veterinario IdVeterinario { get; set; } 
        public List<Veterinario> Veterinarios { get; set; }
    }
}
