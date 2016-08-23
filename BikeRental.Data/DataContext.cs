using System.Data.Entity;
using BikeRental.Core;
using BikeRental.Data.Mapping;

namespace BikeRental.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikesTypes> BikesTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext() : base("BikeRentalDB")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new BikeRentalInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BikeMap());
            modelBuilder.Configurations.Add(new BikesTypesMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new RolesMap());
            modelBuilder.Configurations.Add(new TypeMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

        private class BikeRentalInitializer :DropCreateDatabaseAlways<DataContext>
        {
            protected override void Seed(DataContext context)
            {

                base.Seed(context);
            }
        }


    }
}
