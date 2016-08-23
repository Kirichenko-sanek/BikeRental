using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class BikesTypesMap : EntityTypeConfiguration<BikesTypes>
    {
        public BikesTypesMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.IdBike).IsRequired();
            Property(m => m.IdType).IsRequired();
            ToTable("BikesTypes");

            HasRequired(m => m.Bike).WithMany(m => m.Type).HasForeignKey(m => m.IdBike).WillCascadeOnDelete(false);
            HasRequired(m=>m.Type).WithMany(m=>m.Bikes).HasForeignKey(m=>m.IdType).WillCascadeOnDelete(false);
        }
    }
}
