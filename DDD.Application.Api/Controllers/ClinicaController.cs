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
        readonly IVeterinarioRepository _veterinarioRepository;

        //Dependency Injection
        public ClinicaController(IClinicaRepository clinicaRepository, IVeterinarioRepository veterinarioRepository)
        {
            _clinicaRepository = clinicaRepository;
            _veterinarioRepository = veterinarioRepository;
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

        [HttpGet("{clinicaId}/veterinarios")]
        public ActionResult VeterinariosDaClinica(int clinicaId)
        {
            var veterinarios = _veterinarioRepository.GetVeterinariosByClinicaId(clinicaId);

            if (veterinarios.Any())
            {
                return Ok(veterinarios);
            }
            else
            {
                return NotFound("Sua clínica não possui veterinários ainda. Cadastre-os.");
            }
        }


        [HttpPost("api/Clinica/Create")] // Método para criar uma clínica
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Clinica> CreateClinica(Clinica clinica)
        {
            _clinicaRepository.InsertClinica(clinica);
            return CreatedAtAction(nameof(GetById), new { id = clinica.ClinicaId }, clinica);
        }

        [HttpPost("api/Clinica/AssociarVeterinario")]
        public IActionResult AssociarVeterinario(int clinicaId, Veterinario veterinario)
        {
            _clinicaRepository.AdicionarVeterinario(clinicaId, veterinario);
            return Ok("Veterinario Cadastrado com sucesso!");
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
        [HttpDelete("api/Clinica/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var clinica = _clinicaRepository.GetClinicaById(id);

                if (clinica == null)
                    return NotFound();

                clinica.Ativo = false;
                _clinicaRepository.UpdateClinica(clinica);
                return Ok("Clínica desativada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("api/Clinica/DesassociarVeterinario")]
        public ActionResult DesassociarVeterinario(int clinicaId, int veterinarioId)
        {
            try
            {
                _clinicaRepository.RemoverVeterinario(clinicaId, veterinarioId);
                return Ok("Veterinário removido com sucesso da clínica.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
