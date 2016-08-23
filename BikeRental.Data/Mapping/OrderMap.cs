using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.DateOrder).IsRequired();
            Property(m => m.IdBike).IsRequired();
            Property(m => m.IdUser).IsRequired();
            Property(m => m.Status).IsRequired();
            Property(m => m.TimeEnd).IsRequired();
            Property(m => m.TimeStart).IsRequired();
            ToTable("Order");

            HasRequired(m=>m.User).WithMany(m=>m.Orders).HasForeignKey(m=>m.IdUser).WillCascadeOnDelete(false);
            HasRequired(m=>m.Bike).WithMany().HasForeignKey(m=>m.IdBike).WillCascadeOnDelete(false);
        }
    }
}
