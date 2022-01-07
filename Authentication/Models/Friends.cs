using Authentication.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Models
{
    public class Friends
    {
        [Key]
        public int friendID { get; set; }
        [Required]
        public string friendname { get; set; }

        [Required]
        public int userId { get; set; }
        [ForeignKey("userId")]
        public User User { get; set; }



        /* public Friends()
         {
             this.Users = new HashSet<User>();
         }
         public virtual ICollection<User> Users { get; set; }*/
    }
}
