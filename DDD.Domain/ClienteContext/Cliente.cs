using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDD.Domain.ClienteContext
{
    public class Cliente : User
    {
        public string Senha { get; set; }
        public int Telefone { get; set; }
        

        [JsonIgnore]
        public List<Animal>? Animais { get; set; }
    }
}
