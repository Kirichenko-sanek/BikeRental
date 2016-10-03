using System;
using System.Collections.Generic;
using System.Web;
using BikeRental.Core;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.Interfases.Manager
{
    public interface IBikeManager<T> : IManager<T> where T : Bike
    {
        AddBikeViewModel AddBikeGet(AddBikeViewModel model);
        void AddBikePost(AddBikeViewModel model, HttpPostedFileBase upload, string url);
        void AddBikeApi(BikeViewModel model);
        List<BikeViewModel> ListBike();
        void DeleteBike(long id);
        void EditStatus(long id);
        EditBikeViewModel EditBikeGet(long id);
        void EditBikePost(EditBikeViewModel model, HttpPostedFileBase upload, string url);
        TakeBikeViewModel TakeBike(TakeBikeViewModel model, long userId);
        DateTime AccessTime(long idBike);
    }
}
