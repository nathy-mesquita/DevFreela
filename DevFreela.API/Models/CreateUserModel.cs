using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DevFreela.API.Models
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
