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
        readonly IAuthenticateRepository _authenticationRepository;

        //Dependency Injection
        public ClienteController(IClienteRepository clienteRepository, IAuthenticateRepository authenticateRepository)
        {
            _clienteRepository = clienteRepository;
            _authenticationRepository = authenticateRepository;
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

        [HttpGet("PesquisarPorCPF/{cpf}")]
        public ActionResult<Cliente> GetByCPF(string cpf)
        {
            return Ok(_clienteRepository.GetClienteByCPF(cpf));
        }

        [HttpGet("{clinicaId}/clientes")]
        public ActionResult ClientesDaClinica(int clinicaId)
        {
            var clientes = _clienteRepository.GetClientesByClinicaId(clinicaId);

            if (clientes.Any())
            {
                return Ok(clientes);
            }
            else
            {
                return NotFound("Sua clínica não possui clientes ainda. Cadastre-os.");
            }
        }

       [HttpPost("api/Clinica/CadastrarCliente")]
        public IActionResult InsertCliente(int clinicaId, Cliente cliente)
        {
            _clienteRepository.InsertCliente(clinicaId, cliente);
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
            return Ok("Animal Cadastrado com sucesso!");
        }

        [HttpDelete("api/Clinica/RetirarAnimal")]
        public ActionResult DesassociarAnimal(int id, int AnimalId)
        {
            try
            {
                _clienteRepository.RemoverAnimal(id, AnimalId);
                return Ok("animal removido com sucesso do cliente.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("api/Cliente/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            var cliente = _authenticationRepository.AuthenticateCliente(email, senha);

            if (cliente == null)
            {
                return Unauthorized("Email ou senha incorretos.");
            }

            return Ok(new { Message = "Login bem-sucedido", ClienteId = cliente.UserId, documento = cliente.CPF, clincia = cliente.ClinicaId });
        }

    }
}
