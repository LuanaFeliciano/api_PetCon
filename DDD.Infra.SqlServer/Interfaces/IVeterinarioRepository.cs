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

        Veterinario GetVeterinarioByCPF(string cpf);
        public void UpdateVeterinario(Veterinario veterinario);
        // M�todo para buscar veterin�rios associados a uma cl�nica espec�fica
        List<Veterinario> GetVeterinariosByClinicaId(int clinicaId);

    }
}
