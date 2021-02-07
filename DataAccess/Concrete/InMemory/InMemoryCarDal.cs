using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,CarBrandId=1,CarColorId=1,CarModelYear=2021,CarDailyPrice=9000,CarDescription="Newest and Fastest Car"},
                new Car{CarId=2,CarBrandId=1,CarColorId=2,CarModelYear=2020,CarDailyPrice=5000,CarDescription="Fast Car"},
                new Car{CarId=3,CarBrandId=2,CarColorId=2,CarModelYear=2019,CarDailyPrice=3000,CarDescription="Family Car"},
                new Car{CarId=4,CarBrandId=2,CarColorId=3,CarModelYear=2018,CarDailyPrice=1500,CarDescription="Off Road Car"},
                new Car{CarId=5,CarBrandId=3,CarColorId=3,CarModelYear=2015,CarDailyPrice=1000,CarDescription="SUV Car"},
                new Car{CarId=6,CarBrandId=4,CarColorId=4,CarModelYear=2009,CarDailyPrice=800,CarDescription="Old Car"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
            
            Console.WriteLine("Car added to list.");
        }

        public void Delete(Car car)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
            
            Console.WriteLine("Car removed from list.");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarBrandId = car.CarBrandId;
            carToUpdate.CarColorId = car.CarColorId;
            carToUpdate.CarModelYear = car.CarModelYear;
            carToUpdate.CarDailyPrice = car.CarDailyPrice;
            carToUpdate.CarDescription = car.CarDescription;

            Console.WriteLine("Car updated.");
        }
    }
}
