using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.Url).IsRequired();
            ToTable("Photo");
        }
    }
}
