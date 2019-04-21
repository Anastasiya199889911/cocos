using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public int id_type_product { get; set;}
        public int price { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string guarant { get; set; }
        public string country { get; set; }
        public DateTime date { get; set; }


        [ForeignKey("id_type_product")]
        public virtual ProductTypes productTypes { get; set; }

        public virtual ICollection<Photos> photo { get; set; }
        public virtual ICollection<ProductCharacteristics> productCharacteristics { get; set; }
        public virtual ICollection<Comments> comments { get; set; }
        public virtual ICollection<Baskets> baskets { get; set; }
    }
}