using MyApp.Domain;
using MyApp.Infrastructure.EntityFramework.EfMaps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework
{
    public class MyAppContext : DbContext
    {
        public MyAppContext() : base("MyApp")
        {
            Database.SetInitializer<MyAppContext>(new DropCreateDatabaseIfModelChanges<MyAppContext>());
        }

        public DbSet<Domain.LegoSet> LegoSets { get; set; }
        public DbSet<Domain.DraftLegoSet> DraftLegoSets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.ComplexType<Money>();
            modelBuilder.Configurations.Add(new LegoSetMap());
            modelBuilder.Configurations.Add(new DraftLegoSetMap());
        }
    }
}
