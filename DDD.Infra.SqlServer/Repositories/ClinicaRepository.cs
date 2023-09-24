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
    public class ClinicaRepository : IClinicaRepository
    {

        private readonly SqlServerContext _context;

        public ClinicaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void DeleteClinica(Clinica clinica)
        {
            try
            {
                _context.Set<Clinica>().Remove(clinica);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Clinica GetClinicaById(int id)
        {
            return _context.Clinicas.Find(id);
        }

        public List<Clinica> GetClinicas()
        {

            var list = _context.Clinicas.ToList();
            return list;

        }

        public void InsertClinica(Clinica clinica)
        {
            try
            {
                _context.Clinicas.Add(clinica);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateClinica(Clinica clinica)
        {
            try
            {
                _context.Entry(clinica).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
