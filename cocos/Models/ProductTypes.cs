using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class ProductTypes
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<CharacteristicByTypes> charact { get; set; }
    }
}