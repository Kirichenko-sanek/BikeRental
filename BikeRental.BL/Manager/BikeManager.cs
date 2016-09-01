using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BikeRental.Core;
using BikeRental.Interfases.Manager;
using BikeRental.Interfases.Repository;
using BikeRental.Interfases.Validator;
using BikeRental.ViewModel.ViewModel;

namespace BikeRental.BL.Manager
{
    public class BikeManager<T> : Manager<T>, IBikeManager<T> where T : Bike
    {
        private readonly ITypeManager<Core.Type> _typeManager;
        private readonly IOrderManager<Order> _orderManager;
        private readonly IManager<Bike> _manager;

        public BikeManager(IRepository<T> repository, IValidator<T> validator, ITypeManager<Core.Type> typeManager,
            IOrderManager<Order> orderManager, IManager<Bike> manager)
            : base(repository, validator)
        {
            _manager = manager;
            _typeManager = typeManager;
            _orderManager = orderManager;
        }

        public AddBikeViewModel AddBikeGet(AddBikeViewModel model)
        {
            model.Types = _typeManager.GetAllTypes();
            return model;
        }

        public void AddBikePost(AddBikeViewModel model, HttpPostedFileBase upload, string url)
        {
            var entity = Mapper.Map<AddBikeViewModel, Bike>(model);
            entity.Photo = new Photo
            {
                Url = AddPhotos.AddImage(upload, url, "/assets/images/Bikes/")
            };
            _manager.Add(entity);
        }


        public List<BikeViewModel> ListBike()
        {
            var bikes = _manager.GetAll();
            var listBikes = new List<BikeViewModel>();
            foreach (var bike in bikes)
            {
                listBikes.Add(Mapper.Map<Bike, BikeViewModel>(bike));
            }

            return listBikes;
        }

        public void DeleteBike(long id)
        {
            var listOrder = new List<Order>();
            var orders = _orderManager.GetOrdersByBike(id);
            foreach (var order in orders)
            {
                listOrder.Add(order);
            }
            foreach (var order in listOrder)
            {
                _orderManager.Delete(order);
            }
            var bike = _manager.GetById(id);
            _manager.Delete(bike);
        }

        public void EditStatus(long id)
        {
            var bike = GetById(id);
            bike.Status = bike.Status != true;
            Update(bike);
        }

        public EditBikeViewModel EditBikeGet(long id)
        {
            var editGet = new EditBikeViewModel
            {
                Types = _typeManager.GetAllTypes(),
                Bike = Mapper.Map<Bike, BikeViewModel>(GetById(id))
            };
            return editGet;
        }

        public void EditBikePost(EditBikeViewModel model, HttpPostedFileBase upload, string url)
        {
            var bike = _manager.GetById(model.Bike.IdBike);
            bike = Mapper.Map<EditBikeViewModel, Bike>(model, bike);
            bike.Photo = new Photo
            {
                Url = AddPhotos.AddImage(upload, url, "/assets/images/Bikes/")
            };
            _manager.Update(bike);
        }

        public TakeBikeViewModel TakeBike(TakeBikeViewModel model, long userId)
        {
            try
            {
                _orderManager.EditAllOrder();
                IQueryable<Bike> bikeList;
                IQueryable<Order> orderList;
                Bike oneBike = null;
                if (model.SelectType == 0 && model.SelectSex == null)
                {
                    bikeList = GetAll().Where(x => x.Status);
                }
                if (model.SelectType != 0 && model.SelectSex != null)
                {
                    bikeList =
                        GetAll().Where(x => (x.Type.Id == model.SelectType && x.Sex == model.SelectSex && x.Status));
                }
                else
                {
                    bikeList =
                        GetAll().Where(x => (x.Type.Id == model.SelectType || x.Sex == model.SelectSex && x.Status));
                }
                
                foreach (var bike in bikeList)
                {
                    orderList = _orderManager.GetOrdersByBike(bike.Id);
                    if (!orderList.Any())
                    {
                        oneBike = bike;
                        break;
                    }

                    foreach (var order in orderList)
                    {
                        if ((model.TimeStart < order.TimeStart && model.TimeEnd < order.TimeStart) ||
                            (model.TimeStart > order.TimeEnd && model.TimeEnd > order.TimeEnd))
                        {
                            if (oneBike == null)
                            {
                                oneBike = bike;
                            }                           
                        }
                    }                    
                }
                if (oneBike == null) throw new Exception("К сожалению на выбранное вами время нет свободных велосипедов");
                var entity = Mapper.Map<TakeBikeViewModel, Order>(model);
                entity.IdBike = oneBike.Id;
                entity.IdUser = userId;
                
                entity.TotalPrice = Convert.ToDecimal(model.TimeEnd.Subtract(model.TimeStart).TotalHours) * oneBike.Price;
                _orderManager.Add(entity);
                return model;
            }
            catch (Exception e)
            {
                Bike bike;
                if (model.SelectType == 0 && model.SelectSex == null)
                {
                    bike = GetAll().FirstOrDefault(x => x.Status);
                }
                if (model.SelectType != 0 && model.SelectSex != null)
                {
                    bike =
                        GetAll().FirstOrDefault(x => (x.Type.Id == model.SelectType && x.Sex == model.SelectSex && x.Status));
                }
                else
                {
                    bike =
                        GetAll().FirstOrDefault(x => (x.Type.Id == model.SelectType || x.Sex == model.SelectSex && x.Status));
                }
                model.PotentialBike = bike.Id;
                model.Error = e.Message;
                return model;
            }
        }

        public DateTime AccessTime(long idBike)
        {
            DateTime accessTime = new DateTime();
            var orderList = _orderManager.GetOrdersByBike(idBike);
            foreach (var order in orderList)
            {
                if (accessTime > order.TimeEnd)
                {
                    accessTime = order.TimeEnd;
                }
            }
            return accessTime;
        }
    }
}
