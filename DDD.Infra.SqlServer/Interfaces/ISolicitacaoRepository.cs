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
    public interface ISolicitacaoRepository
    {
        public Solicitacao GetSolicitacaoById(int id);

        public List<Solicitacao> GetSolicitacoes();
        public Solicitacao GetSolicitacaoByClienteId(int clienteId);
        public Solicitacao InsertSolicitacao(int clienteId, int animalId, string descricao, string periodo, string urgencia);
    }
}
