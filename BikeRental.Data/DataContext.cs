using System.Collections.Generic;
using System.Data.Entity;
using BikeRental.BL;
using BikeRental.Core;
using BikeRental.Data.Mapping;

namespace BikeRental.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
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
                var roles = new List<Roles>
                {
                    new Roles()
                    {
                        Role = "Admin"
                    },
                    new Roles()
                    {
                        Role = "User"
                    }
                };
                foreach (var role in roles) context.Roles.Add(role);
                context.SaveChanges();

                var photos = new List<Photo>
                {
                    new Photo()
                    {
                        Url = "111"
                    }
                };
                foreach (var photo in photos) context.Photos.Add(photo);
                context.SaveChanges();

                var types = new List<Type>
                {
                    new Type()
                    {
                        NameType = "Bikee"
                    }
                };
                foreach (var type in types) context.Types.Add(type);
                context.SaveChanges();
                

                var salt = PasswordHashing.GenerateSaltValue();
                var pass = PasswordHashing.HashPassword("123456", salt);
                var users = new List<User>
                {
                    new User()
                    {
                        FirstName = "Alexander",
                        LastName = "Kirichenko",
                        Password = pass,
                        PasswordSalt = salt,
                        Email = "kirichenko-sanek@mail.ru",
                        IsActivated = true,
                        IdRole = 1,
                        IdPhoto = 1

                    }
                };
                foreach (var user in users) context.Users.Add(user);
                context.SaveChanges();


                var bikes = new List<Bike>
                {
                    new Bike()
                    {
                        Sex = "M",
                        Price = 50,
                        IdType = 1,
                        IdPhoto = 1
                    },
                    new Bike()
                    {
                        Sex = "W",
                        Price = 50,
                        IdType = 1,
                        IdPhoto = 1
                    }
                };
                foreach (var bike in bikes) context.Bikes.Add(bike);
                context.SaveChanges();

                /*var orders = new List<Order>
                {
                    new Order()
                    {
                        
                    }
                };
                foreach (var order in orders) context.Orders.Add(order);
                context.SaveChanges();*/
                

                base.Seed(context);
            }
        }


    }
}
