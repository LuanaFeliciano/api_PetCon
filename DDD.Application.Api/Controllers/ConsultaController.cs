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
            var jsonString = _consultaRepository.GetConsultas();
            return Content(jsonString, "application/json");
            
        }

        [HttpGet("{id}")]
        public ActionResult<Consulta> GetById(int id)
        {
            return Ok(_consultaRepository.GetConsultaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Consulta> CreateConsulta([FromBody] ConsultaCreateModel model)
        {
            Consulta consultaIdSaved = _consultaRepository.InsertConsulta(model.IdVeterinario, model.IdAnimal, model.Descricao, model.DataConsulta);
            return CreatedAtAction(nameof(GetById), new { id = consultaIdSaved.IdConsulta }, consultaIdSaved);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Consulta consulta)
        {
            try
            {
                if (consulta == null)
                {
                    return NotFound();
                }
                    

                _consultaRepository.UpdateConsulta(consulta);
                return Ok("Consulta Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                _consultaRepository.DeleteConsulta(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
