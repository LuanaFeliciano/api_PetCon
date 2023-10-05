using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ClienteContext
{
    public class Cliente : User
    {
        public string Senha { get; set; }
        public int Telefone { get; set; }
        public bool Ativo { get; set; }

        public List<Animal> Animais { get; set; }
    }
}
