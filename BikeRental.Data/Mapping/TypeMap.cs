using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BikeRental.Core;

namespace BikeRental.Data.Mapping
{
    class TypeMap : EntityTypeConfiguration<Type>
    {
        public TypeMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.NameType).IsRequired();
            ToTable("Type");
        }
    }
}
