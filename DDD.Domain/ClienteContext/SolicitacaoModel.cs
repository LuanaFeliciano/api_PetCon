using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ClienteContext
{
    public class SolicitacaoModel
    {

        public int SolicitacaoId { get; set; }

        public int AnimalId { get; set; }

        public int ClienteId { get; set; }

        public string Periodo { get; set; }

        public string Descricao { get; set; }

        public string Urgencia { get; set; }
    }
}
