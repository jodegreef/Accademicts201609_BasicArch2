using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.EntityFramework.EfMaps
{
    public class DraftLegoSetMap : EntityTypeConfiguration<DraftLegoSet>
    {
        public DraftLegoSetMap()
        {
            this.ToTable("DraftLegoSet");

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
