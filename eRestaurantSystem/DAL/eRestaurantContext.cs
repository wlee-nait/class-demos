using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using System.Data.Entity;
#endregion

namespace eRestaurantSystem.DAL
{
    //hookup to Entity Framework via the DbContext base class
    internal class eRestaurantContext : DbContext
    {
        //constructor pass to the base class the name value for the 
        //connection string to the database found in WebConnectionStrings.config
        public eRestaurantContext() : base("name=EatIn") { }

        //One DbSet is created for each entity to be referenced by your application
        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        //public DbSet<Table> Tables { get; set; }
    }
}
