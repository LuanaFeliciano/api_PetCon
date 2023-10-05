using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IClienteRepository
    {
        public List<Cliente> GetCliente();
        public Cliente GetClienteById(int id);
        public void InsertCliente(Cliente cliente);
        public void UpdateCliente(Cliente cliente);
        public void DeleteCliente(int id);
        public void AdicionarAnimal(int clienteId, Animal animal);
        public void RemoverAnimal(int clienteId, int animalId);
    }
}
