﻿using System;
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
                    m.IdType = p.Id;
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
                    m.IdOrder = p.Id;
                    m.IdUser = p.IdUser;
                    m.IdBike = p.IdBike;
                    m.TimeStart = p.TimeStart;
                    m.TimeEnd = p.TimeEnd;
                    m.DateOrder = p.DateOrder;
                    m.Status = p.Status;
                    m.BeforeStart = p.TimeStart >= DateTime.Now ? p.TimeStart.Subtract(DateTime.Now) : TimeSpan.Zero;
                    m.BeforeEnd = p.TimeEnd >= DateTime.Now ? p.TimeEnd.Subtract(DateTime.Now) : TimeSpan.Zero;
                    m.Photo = p.Bike.Photo.Url;
                    m.PriceOrder = p.TotalPrice;
                });
                cfg.CreateMap<AddBikeViewModel, Bike>().AfterMap((p, m) =>
                {
                    m.Sex = p.Bike.Sex;
                    m.Price = p.Bike.Price;
                    m.IdType = p.Bike.IdType;
                    m.Status = true;
                });
                cfg.CreateMap<Bike, BikeViewModel>().AfterMap((p, m) =>
                {
                    m.Sex = p.Sex;
                    m.Price = p.Price;
                    m.Status = p.Status;
                    m.IdBike = p.Id;
                    m.Type = p.Type.NameType;
                    m.Photo = p.Photo.Url;
                });
            });
        }

        
    }
}