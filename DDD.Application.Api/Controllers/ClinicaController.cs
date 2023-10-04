using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using DDD.Infra.SqlServer.Repositories;
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
        readonly IAuthenticateRepository _authenticationRepository;

        //Dependency Injection
        public ClinicaController(IClinicaRepository clinicaRepository, IVeterinarioRepository veterinarioRepository, IAuthenticateRepository authenticateRepository)
        {
            _clinicaRepository = clinicaRepository;
            _veterinarioRepository = veterinarioRepository;
            _authenticationRepository = authenticateRepository;
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


        [HttpPost("api/Clinica/Create")] // Método para criar uma clínica
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

        [HttpPost("api/Clinica/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var clinica = _authenticationRepository.Authenticate(email, senha);

            if (clinica == null)
            {
                return Unauthorized("Email ou senha incorretos.");
            }

            return Ok("Login bem-sucedido");
        }

    }
}
