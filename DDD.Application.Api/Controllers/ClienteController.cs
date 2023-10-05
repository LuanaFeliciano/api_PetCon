using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using DDD.Infra.SqlServer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly IClienteRepository _clienteRepository;

        //Dependency Injection
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return Ok(_clienteRepository.GetCliente());
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            return Ok(_clienteRepository.GetClienteById(id));
        }

        [HttpPost("api/Cliente/Create")] // Método para criar um cliente
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cliente> CreateCliente(Cliente cliente)
        {
            _clienteRepository.InsertCliente(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.UserId }, cliente);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();

                _clienteRepository.UpdateCliente(cliente);
                return Ok("Cliente Atualizado com sucesso!");
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

                    _clienteRepository.DeleteCliente(id);
                    return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("api/Clinica/IncluirAnimal")]
        public IActionResult AssociarAnimal(int id, Animal animal)
        {
            _clienteRepository.AdicionarAnimal(id, animal);
            return Ok("Cliente Cadastrado com sucesso!");
        }

        [HttpDelete("api/Clinica/RetirarAnimal")]
        public ActionResult DesassociarAnimal(int id, int AnimalId)
        {
            try
            {
                _clienteRepository.RemoverAnimal(id, AnimalId);
                return Ok("Cliente removido com sucesso da clínica.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
