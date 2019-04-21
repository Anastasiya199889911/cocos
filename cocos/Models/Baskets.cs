using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Baskets
    {
        [Key]
        public int id { get; set; }
        public int id_product { get; set; }
        public int? id_user { get; set; }
        public int count { get; set; }

        //public Characteristics characteristics { get; set; }

        [ForeignKey("id_product")]
        public virtual Products product { get; set; }
        [ForeignKey("id_user")]
        public virtual Users user { get; set; }
    }
}