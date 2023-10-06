using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlServerContext _context;

        public ClienteRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public List<Cliente> GetCliente()
        {

            var list = _context.Clientes.ToList().Where(c => c.Ativo).ToList();
            return list;

        }

        public List<Cliente> GetClientesByClinicaId(int clinicaId)
        {
            var clientes = _context.Clientes
                .Include(v => v.Clinica)
                .Where(v => v.ClinicaId == clinicaId)
                .ToList();

            return clientes;
        }

        //public void InsertCliente(Cliente cliente)
        //{
        //    try
        //    {

        //        _context.Clientes.Add(cliente);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log exception
        //    }
        //}

        public void InsertCliente(int clinicaId, Cliente cliente)
        {
            var clinica = _context.Clinicas.Include(c => c.Clientes).FirstOrDefault(c => c.ClinicaId == clinicaId);
            if (clinica != null)
            {
                clinica.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }


        public void UpdateCliente(Cliente cliente)
        {
            try
            {
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCliente(int id) 
        {
            try
            {
                var excluir = _context.Clientes.Find(id);
                excluir.Ativo = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AdicionarAnimal(int id, Animal animal)
        {
            var cliente = _context.Clientes.Include(c => c.Animais).FirstOrDefault(c => c.UserId == id);
            if (cliente != null)
            {
                cliente.Animais.Add(animal);
                _context.SaveChanges();
            }
        }

        public void RemoverAnimal(int id, int AnimalId)
        {
            var cliente = _context.Clientes.Include(c => c.Animais).FirstOrDefault(c => c.UserId == id);
            if (cliente != null)
            {
                var animal = cliente.Animais.FirstOrDefault(v => v.AnimalId == id);
                if (animal != null)
                {
                    cliente.Animais.Remove(animal);
                    _context.SaveChanges();
                }
            }
        }

        public Cliente Login(string email, string senha)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Email == email);

            if (cliente == null)
            {
                return null;
            }

            if (cliente.Senha != senha)
            {
                return null;
            }

            return cliente;
        }
    }
}
