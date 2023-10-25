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
    public class ConsultaCreateModel
    {
        public int IdVeterinario { get; set; }
        public int IdAnimal { get; set; }
        public string Descricao { get; set; }
        public string DataConsulta { get; set; }
    }

}
