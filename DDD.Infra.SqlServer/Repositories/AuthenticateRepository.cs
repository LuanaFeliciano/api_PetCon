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
    public class AuthenticateRepository : IAuthenticateRepository
    {

        private readonly SqlServerContext _context;

        public AuthenticateRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Clinica Authenticate(string email, string senha)
        {
            // Verifique se h� uma cl�nica com o email fornecido e a senha correspondente
            var clinica = _context.Clinicas.FirstOrDefault(c => c.Email == email && c.SenhaAcesso == senha);

            return clinica;
        }

        //public Cliente Authenticate(string email, string senha)
        //{
            // Verifique se h� uma cl�nica com o email fornecido e a senha correspondente
        //    var cliente = _context.Cliente.FirstOrDefault(c => c.Email == email && c.SenhaAcesso == senha);

         //   return cliente;
       // }
    }
}
