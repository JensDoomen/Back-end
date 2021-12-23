using Authentication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class UserDTO
    {
        public string email { get; set; }
        public string token { get; set; }
    }
}
