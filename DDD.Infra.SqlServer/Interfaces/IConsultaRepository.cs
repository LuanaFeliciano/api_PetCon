using DDD.Domain.ClinicaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IConsultaRepository
    {
        public string GetConsultas();
        public Consulta GetConsultaById(int id);
        public Consulta InsertConsulta(int idVeterinario, int animalId, string descricao, string dataConsulta);
        public void DeleteConsulta(int id);

        public void UpdateConsulta(Consulta consulta);

        public string GetConsultasByClienteId(int clienteId);
    }
}
