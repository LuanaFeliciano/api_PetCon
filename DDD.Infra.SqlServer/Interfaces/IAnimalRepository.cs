using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IAnimalRepository
    {
        public List<Animal> GetAnimais();
        public Animal GetAnimalById(int id);
        public void InsertAnimal(Animal animal);
        public void UpdateAnimal(Animal animal);
        public void DeleteAnimal(int id);

        List<Animal> GetAnimaisByClienteId(int clienteId);
    }
}
