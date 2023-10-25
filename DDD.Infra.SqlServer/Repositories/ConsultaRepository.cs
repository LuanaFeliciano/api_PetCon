using DDD.Domain.ClinicaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly SqlServerContext _context;

        public ConsultaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<Consulta> GetConsultas()
        {
            var list = _context.Consultas.Include(c => c.Veterinarios).Include(c => c.Animal).ToList();
            return list;
        }


        public Consulta GetConsultaById(int id)
        {
            return _context.Consultas.Find(id);
        }
        public Consulta InsertConsulta(int idVeterinario, int idAnimal, string descricao, string dataConsulta)
        {
            var veterinaria = _context.Veterinarios.First(i => i.UserId == idVeterinario);
            var animal = _context.Animais.First(i => i.AnimalId == idAnimal);

            var Consulta = new Consulta
            {
                Veterinarios = veterinaria,
                Animal = animal,
                Status = "Agendado",
                Descricao = descricao,
                DataConsulta = dataConsulta
            };

            try
            {

                _context.Add(Consulta);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return Consulta;
        }
    }

}
