using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class ProductCharacteristics
    {
        [Key]
        public int id { get; set; }
        public int id_characteristic { get; set; }
        public int id_product { get; set; }
        public string text { get; set; }
        [ForeignKey("id_product")]
        public virtual Products products { get; set; }
        [ForeignKey("id_characteristic")]
        public virtual Characteristics characteriactics { get; set; }
    }
}