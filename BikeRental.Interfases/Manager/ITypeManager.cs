using System.Collections.Generic;
using System.Linq;
using BikeRental.Core;
using BikeRental.ViewModel;

namespace BikeRental.Interfases.Manager
{
    public interface ITypeManager<T> : IManager<T> where T : Type
    {
        List<TypeViewModel> GetAllTypes();
        void AddType(AddTypeViewModel model);
    }
}
