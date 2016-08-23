using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class BikeMap : EntityTypeConfiguration<Bike>
    {
        public BikeMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Model).IsRequired();
            Property(m => m.Sex).IsRequired();
            Property(m => m.Price).IsRequired();
            Property(m => m.Status).IsRequired();
            ToTable("Bike");

            HasRequired(m => m.Photo).WithMany().HasForeignKey(m=>m.IdPhoto).WillCascadeOnDelete(false);
            HasRequired(m=>m.Type).WithMany().HasForeignKey(m=>m.IdType).WillCascadeOnDelete(false);
        }
    }
}
