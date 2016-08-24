using System;
using AutoMapper;
using BikeRental.Core;
using BikeRental.ViewModel;
using Type = BikeRental.Core.Type;

namespace BikeRental.App_Start
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Type, TypeViewModel>().AfterMap((p, m) =>
                {
                    m.NameType = p.NameType;
                });
                cfg.CreateMap<TakeBikeViewModel, Order>().AfterMap((p, m) =>
                {
                    m.DateOrder = DateTime.Now;
                    m.TimeStart = p.TimeStart;
                    m.TimeEnd = p.TimeEnd;
                    m.Status = true;
                });
                cfg.CreateMap<Order, OrderViewModel>().AfterMap((p, m) =>
                {
                    m.IdUser = p.IdUser;
                    m.IdBike = p.IdBike;
                    m.TimeStart = p.TimeStart;
                    m.TimeEnd = p.TimeEnd;
                    m.DateOrder = p.DateOrder;
                    m.Status = p.Status;
                });
            });
        }

        
    }
}