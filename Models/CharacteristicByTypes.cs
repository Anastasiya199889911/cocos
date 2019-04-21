using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class CharacteristicByTypes
    {
        [Key]
        public int id { get; set; }
        public int id_type_product { get; set;}
        public int id_characteristics { get; set; }

        //public Characteristics characteristics { get; set; }

        [ForeignKey("id_type_product")]
        public virtual ProductTypes productTypes { get; set; }
        [ForeignKey("id_characteristics")]
        public virtual Characteristics characteristics { get; set; }

        //public virtual ICollection<ProductTypes> prodTypes { get; set; }
        //public virtual ICollection<Characteristics> charact { get; set; }
    }
}