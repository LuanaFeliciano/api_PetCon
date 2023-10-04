using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        readonly IClinicaRepository _clinicaRepository;
        readonly IVeterinarioRepository _veterinarioRepository;

        //Dependency Injection
        public VeterinarioController(IClinicaRepository clinicaRepository, IVeterinarioRepository veterinarioRepository)
        {
            _clinicaRepository = clinicaRepository;
            _veterinarioRepository = veterinarioRepository;
        }


        [HttpGet]
        public ActionResult<List<Veterinario>> Get()
        {
            return Ok(_veterinarioRepository.GetVeterinarios());
        }

        [HttpGet("{id}")]
        public ActionResult<Veterinario> GetById(int id)
        {
            return Ok(_veterinarioRepository.GetVeterinarioById(id));
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

        [HttpPost("api/Clinica/AssociarVeterinario")]
        public IActionResult AssociarVeterinario(int clinicaId, Veterinario veterinario)
        {
            _clinicaRepository.AdicionarVeterinario(clinicaId, veterinario);
            return Ok("Veterinario Cadastrado com sucesso!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] Veterinario veterinario)
        {
            try
            {
                if (veterinario == null)
                    return NotFound();

                _veterinarioRepository.UpdateVeterinario(veterinario);
                return Ok("Veterinario Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
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
