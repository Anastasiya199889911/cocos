using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool is_admin { get; set; }
        public virtual ICollection<Baskets> baskets { get; set; }
    }
}