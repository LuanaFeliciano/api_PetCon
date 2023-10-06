using DDD.Domain.ClienteContext;
using DDD.Domain.ClinicaContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IConsultaRepository
    {
        public List<Consulta> GetConsultas();
        public Consulta GetConsultaById(int id);

        public Consulta InsertConsulta(int idVeterinario, int animalId);

    }
}
