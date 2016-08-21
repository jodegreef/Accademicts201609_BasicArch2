using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework.EfMaps
{
    public class LegoSetMap : EntityTypeConfiguration<LegoSet>
    {
        public LegoSetMap()
        {
            this.ToTable("LegoSet");

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
