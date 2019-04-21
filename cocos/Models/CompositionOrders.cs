using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class CompositionOrders
    {
        [Key]
        public int id { get; set; }
        public int id_order { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }

        [ForeignKey("id_order")]
        public virtual Orders order { get; set; }
    }
}