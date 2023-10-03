using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        readonly IAnimalRepository _animalRepository;

        //Dependency Injection
        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        [HttpGet]
        public ActionResult<List<Animal>> Get()
        {
            return Ok(_animalRepository.GetAnimais());
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            return Ok(_animalRepository.GetAnimalById(id));
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Animal> CreateAnimal(Animal animal)
        {

            _animalRepository.InsertAnimal(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.AnimalId }, animal);
        }

        [HttpPut]

        public ActionResult Put([FromBody] Animal animal)
        {
            try
            {
                if (animal == null)
                    return NotFound();

                _animalRepository.UpdateAnimal(animal);
                return Ok("Animal atualizado com sucesso!");
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
                
                   _animalRepository.DeleteAnimal(id);
                   return Ok("Animal removido com sucesso!");
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
