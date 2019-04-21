using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Photos
    {
        [Key]
        public int id { get; set; }
        public int id_product { get; set; }
        public string photo { get; set; }
        public bool is_main { get; set; }

        //public virtual ICollection<CharacteristicByTypes> charact { get; set; }
        [ForeignKey("id_product")]
        public virtual Products products { get; set; }
    }
}