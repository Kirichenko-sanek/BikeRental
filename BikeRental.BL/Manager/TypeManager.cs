using System.Collections.Generic;
using AutoMapper;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.BL.Manager
{
    public class TypeManager<T> : Manager<T>, ITypeManager<T> where T : Type
    {
        private readonly IManager<Type> _manager;
        public TypeManager(IManager<Type> manager, IRepository<T> repository, IValidator<T> validator)
            : base(repository, validator)
        {
            _manager = manager;
        }

        public List<TypeViewModel> GetAllTypes()
        {
            var types = new List<TypeViewModel>();
            var typesList = GetAll();
            foreach (var type in typesList)
            {
                types.Add(Mapper.Map<Core.Type, TypeViewModel>(type));
            }
            return types;
        }

        public void AddType(AddTypeViewModel model)
        {
            var entity = Mapper.Map<AddTypeViewModel,Type>(model);
            _manager.Add(entity);
        }
    }
}
