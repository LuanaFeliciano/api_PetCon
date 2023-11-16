using DDD.Domain.ClinicaContext;
using DDD.Infra.SqlServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using DDD.Domain.SecretariaContext;

namespace DDD.Infra.SqlServer.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly SqlServerContext _context;

        public ConsultaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public string GetConsultas()
        {


            var consultas = _context.Consultas
                .Include(c => c.Veterinarios)
                    .ThenInclude(v => v.Clinica)
                .Include(c => c.Animal)
                    .ThenInclude(a => a.Clientes)
                .ToList();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                // Outras configurações...
            };

            var jsonString = JsonSerializer.Serialize(consultas, options);

            return jsonString;
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
                Status = "Agendada",
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

        public void DeleteConsulta(int id)
        {
            try
            {
                var excluir = _context.Consultas.Find(id);
                excluir.Status = "Cancelada";
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateConsulta(Consulta consulta)
        {
            try
            {
                _context.Entry(consulta).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
