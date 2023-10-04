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
    public class AnimalRepository : IAnimalRepository
    {
        private readonly SqlServerContext _context;

        public AnimalRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Animal GetAnimalById(int id)
        {
            return _context.Animais.Find(id);
        }

        public List<Animal> GetAnimais()
        {

            var list = _context.Animais.ToList();
            return list;

        }

        public void InsertAnimal(Animal animal)
        {
            try
            {

                _context.Animais.Add(animal);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception
            }
        }


        public void UpdateAnimal(Animal animal)
        {
            try
            {
                _context.Entry(animal).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteAnimal(int id)
        {
            try
            {
                var excluir = _context.Animais.Find(id);
                excluir.Ativo = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
