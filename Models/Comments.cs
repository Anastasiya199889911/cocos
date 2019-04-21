using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Comments
    {
        [Key]
        public int id { get; set; }
        public int id_product { get; set; }
        public int id_user { get; set; }
        public string text { get; set; }
        public string plus { get; set; }
        public string minus { get; set; }
        
        public DateTime date { get; set; }
        [ForeignKey("id_product")]
        public virtual Products products { get; set; }
        [ForeignKey("id_user")]
        public virtual Users users { get; set; }
    }
}