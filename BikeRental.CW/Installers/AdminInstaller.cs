using System.Web.Mvc;
using BikeRental.BL.Manager;
using BikeRental.BL.Validator;
using BikeRental.Core;
using BikeRental.Data;
using BikeRental.Data.Repository;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;

namespace BikeRental.CW.Installers
{
    public class AdminInstaller : IWindsorInstaller
    {
        private const string WebAssemblyName = "BikeRental";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.Name)));

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<WindsorControllerFactory>());

            //Repository
            container.Register(Component.For<DataContext>().LifestyleSingleton());
            container.Register(
                Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());            

            //Validator
            container.Register(
                Component.For(typeof(IValidator<User>)).ImplementedBy(typeof(UserValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Type>)).ImplementedBy(typeof(TypeValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Bike>)).ImplementedBy(typeof(BikeValidator)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IValidator<Order>)).ImplementedBy(typeof(OrderValidator)).LifestyleTransient());



            //Managers
            container.Register(Component.For(typeof(IManager<>)).ImplementedBy(typeof(Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IUserManager<>)).ImplementedBy(typeof(UserManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(ITypeManager<>)).ImplementedBy(typeof(TypeManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IBikeManager<>)).ImplementedBy(typeof(BikeManager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof(IOrderManager<>)).ImplementedBy(typeof(OrderManager<>)).LifestyleTransient());



            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}