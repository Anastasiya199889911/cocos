using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Orders
    {
        [Key]
        public int id { get; set; }
        public int? id_user { get; set; }
        public string fio { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime date { get; set; }
        public virtual ICollection<CompositionOrders> compositionOrder { get; set; }
    }
}