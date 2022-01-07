using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Authentication.Models;

namespace Authentication.Data
{
    public class User
    {
       /* public User()
        {
            this.Users = new HashSet<User.User>();

        }
        public virtual ICollection<User.User> Users { get; set; }

        [ForeignKey("userId")]*/

        [Key]
        public int userId { get; set; }
        //[Required]
        public string name { get; set; }
        //[Required]
        public string email { get; set; }
       // [Required]
        public string password { get; set; }

        //public List<Friends> Friends { get; set; }

    }
}

