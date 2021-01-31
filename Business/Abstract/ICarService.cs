﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllById(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}