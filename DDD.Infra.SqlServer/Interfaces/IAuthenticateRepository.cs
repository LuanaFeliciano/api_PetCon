using DDD.Domain.ClienteContext;
using DDD.Domain.SecretariaContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SqlServer.Interfaces
{
    public interface IAuthenticateRepository
    {
        public Clinica Authenticate(string email, string senha);

        public Cliente AuthenticateCliente(string email, string senha);

    }
}
