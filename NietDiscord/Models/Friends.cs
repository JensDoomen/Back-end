using Authentication.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NietDiscord.Models
{
    public class Friends
    {
        [Key]
        public int friendID { get; set; }
        
        public Friends()
        {
            this.Users = new HashSet<User>();
        }
        public virtual ICollection<User> Users { get; set; }

        /*[ForeignKey]
        public List<>*/
        


       /* [Required]
        public string friendname { get; set; }*/
      
        
    }
}
