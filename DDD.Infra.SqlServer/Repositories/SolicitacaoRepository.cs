using DDD.Domain.ClinicaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using DDD.Domain.SecretariaContext;
using DDD.Domain.ClienteContext;

namespace DDD.Infra.SqlServer.Repositories
{
    public class SolicitacaoRepository : ISolicitacaoRepository
    {
        private readonly SqlServerContext _context;

        public SolicitacaoRepository(SqlServerContext context)
        {
            _context = context;
        }

        List<Solicitacao> ISolicitacaoRepository.GetSolicitacoes()
        {
            throw new NotImplementedException();
        }

        public Solicitacao GetSolicitacaoByClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }
        public Solicitacao GetSolicitacaoById(int id)
        {
            return _context.Solicitacoes.Find(id);
        }


        public Solicitacao InsertSolicitacao(int clienteId, int animalId, string descricao, string periodo, string urgencia)
        {
            var cliente = _context.Clientes.First(i => i.UserId == clienteId);
            var animal = _context.Animais.First(i => i.AnimalId == animalId);

            var Solicitacao = new Solicitacao
            {
                ClienteId = clienteId,
                AnimalId = animalId,
                Cliente = cliente,
                Animal = animal,
                Descricao = descricao,
                Periodo = periodo,
                Urgencia = urgencia
            };

            try
            {

                _context.Add(Solicitacao);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return Solicitacao;
        }
    }

}
