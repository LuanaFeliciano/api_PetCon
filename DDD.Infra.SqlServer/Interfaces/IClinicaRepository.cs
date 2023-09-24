using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IClinicaRepository
    {
        public List<Clinica> GetClinicas();
        public Clinica GetClinicaById(int id);
        public void InsertClinica(Clinica clinica);
        public void UpdateClinica(Clinica clinica);
        public void DeleteClinica(Clinica clinica);
        //public void AdicionarVeterinario(int clinicaId, Veterinario veterinario); // Adicionar veterinário à clínica
        //public void RemoverVeterinario(int clinicaId, int veterinarioId); // Remover veterinário da clínica

    }
}
