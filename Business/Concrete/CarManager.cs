using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarDescription.Length >= 2 && car.CarDailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car added.");
            }
            else
            {
                Console.WriteLine("Car description must be at least 2 letters and daily price must be more then zero.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car deleted.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.CarBrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.CarColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car updated.");
        }
    }
}
