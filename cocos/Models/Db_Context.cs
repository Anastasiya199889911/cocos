using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cocos.Models
{
    public class Db_Context:DbContext
    {
        public Db_Context(string connection)
        {
            Database.Connection.ConnectionString = connection;
        }

        public DbSet<CharacteristicByTypes> CharacteristicByTypes { get; set; }
        public DbSet<Characteristics> Characteristics { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<ListWishes> ListWishes { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<ProductCharacteristics> ProductCharacteristics { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Baskets> Baskets { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<CompositionOrders> CompositionOrders { get; set; }
        public BasketHelp BasketHelp { get; set; }

    }
}