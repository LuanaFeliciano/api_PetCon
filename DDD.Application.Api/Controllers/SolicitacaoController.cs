using DDD.Domain.ClienteContext;
using DDD.Domain.ClinicaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using DDD.Infra.SqlServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        readonly ISolicitacaoRepository _solicitacaoRepository;

        //Dependency Injection
        public SolicitacaoController(ISolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Consulta> GetById(int id)
        {
            return Ok(_solicitacaoRepository.GetSolicitacaoById(id));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Solicitacao> CreateSolicitacao([FromBody] SolicitacaoModel model)
        {
            Solicitacao SolicitacaoIdSaved = _solicitacaoRepository.InsertSolicitacao(model.ClienteId, model.AnimalId, model.Descricao, model.Periodo, model.Urgencia);
            return CreatedAtAction(nameof(GetById), new { id = SolicitacaoIdSaved.SolicitacaoId }, SolicitacaoIdSaved);
        }

    }
}
