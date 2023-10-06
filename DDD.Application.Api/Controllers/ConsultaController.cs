using DDD.Domain.ClienteContext;
using DDD.Domain.ClinicaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        readonly IConsultaRepository _consultaRepository;

        //Dependency Injection
        public ConsultaController(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }


        [HttpGet]
        public ActionResult<List<Consulta>> Get()
        {
            return Ok(_consultaRepository.GetConsultas());
        }

        [HttpGet("{id}")]
        public ActionResult<Consulta> GetById(int id)
        {
            return Ok(_consultaRepository.GetConsultaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Consulta> CreateConsulta(int idVeterinario, int idAnimal)
        {
            Consulta consultaIdSaved = _consultaRepository.InsertConsulta(idVeterinario, idAnimal);
            return CreatedAtAction(nameof(GetById), new { id = consultaIdSaved.IdConsulta }, consultaIdSaved);
        }
    }
}
