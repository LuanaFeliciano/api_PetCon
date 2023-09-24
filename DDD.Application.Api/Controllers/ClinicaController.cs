using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        readonly IClinicaRepository _clinicaRepository;

        //Dependency Injection
        public ClinicaController(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        
        [HttpGet]
        public ActionResult<List<Clinica>> Get()
        {
            return Ok(_clinicaRepository.GetClinicas());
        }

        [HttpGet("{id}")]
        public ActionResult<Clinica> GetById(int id)
        {
            return Ok(_clinicaRepository.GetClinicaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clinica> CreateClinica(Clinica clinica)
        {
            _clinicaRepository.InsertClinica(clinica);
            return CreatedAtAction(nameof(GetById), new { id = clinica.ClinicaId }, clinica);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Clinica clinica)
        {
            try
            {
                if (clinica == null)
                    return NotFound();

                _clinicaRepository.UpdateClinica(clinica);
                return Ok("Clinica Atualizada com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Clinica clinica)
        {
            try
            {
                if (clinica == null)
                    return NotFound();

                _clinicaRepository.DeleteClinica(clinica);
                return Ok("Clinica Removida com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
