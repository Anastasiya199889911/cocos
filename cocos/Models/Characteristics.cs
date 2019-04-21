using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Characteristics
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<CharacteristicByTypes> characteristicByTypes { get; set; }
        //public Characteristics()
        //{
        //    characteristicByTypes = new List<CharacteristicByTypes>();
        //}

    }
}