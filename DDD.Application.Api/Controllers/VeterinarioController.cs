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
        readonly IVeterinarioRepository _veterinarioRepository;

        //Dependency Injection
        public VeterinarioController(IVeterinarioRepository veterinarioRepository)
        {
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

    }
}
