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
    public class VeterinarioRepository : IVeterinarioRepository
    {

        private readonly SqlServerContext _context;

        public VeterinarioRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Veterinario GetVeterinarioById(int id)
        {
            return _context.Veterinarios.Find(id);
        }

        public List<Veterinario> GetVeterinarios()
        {
            var list = _context.Veterinarios.ToList();
            return list;

        }

        public List<Veterinario> GetVeterinariosByClinicaId(int clinicaId)
        {
            var veterinarios = _context.Veterinarios
                .Include(v => v.Clinica)
                .Where(v => v.ClinicaId == clinicaId)
                .ToList();

            return veterinarios;
        }

        public void UpdateVeterinario(Veterinario veterinario)
        {
            try
            {
                _context.Entry(veterinario).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
