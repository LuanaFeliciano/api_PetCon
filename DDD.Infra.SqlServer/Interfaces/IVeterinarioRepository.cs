using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IVeterinarioRepository
    {
        List<Veterinario> GetVeterinarios();
        Veterinario GetVeterinarioById(int id);
        public void UpdateVeterinario(Veterinario veterinario);
        // Método para buscar veterinários associados a uma clínica específica
        List<Veterinario> GetVeterinariosByClinicaId(int clinicaId);

    }
}
