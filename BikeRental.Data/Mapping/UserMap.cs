using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.Id);            
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.FirstName).IsRequired().HasMaxLength(30);
            Property(m => m.LastName).IsRequired().HasMaxLength(30);
            Property(m => m.Email).IsRequired().HasMaxLength(50);
            Property(m => m.Password).IsRequired();
            Property(m => m.PasswordSalt).IsRequired();
            Property(m => m.IsActivated).IsRequired();
            ToTable("User");

            HasRequired(m => m.Roles).WithMany().HasForeignKey(m=>m.IdRole).WillCascadeOnDelete(false);
            HasRequired(m=>m.Photo).WithMany().HasForeignKey(m=>m.IdPhoto).WillCascadeOnDelete(false);
            
        }
    }
}
