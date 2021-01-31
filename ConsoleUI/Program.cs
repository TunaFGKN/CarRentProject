using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarDescription);
            }
            
            foreach (var car in carManager.GetAllById(5))
            {
                Console.WriteLine(car.CarDescription);
            }

            carManager.Add(new Car { CarId = 7, CarBrandId = 5, CarColorId = 1, CarDailyPrice = 1250, CarModelYear = 2016, CarDescription = "New Car" });

            carManager.Update(new Car { CarId = 7, CarBrandId = 6, CarColorId = 2, CarDailyPrice = 1500, CarModelYear = 2016, CarDescription = "Updated new car" });

            foreach (var car in carManager.GetAllById(7))
            {
                Console.WriteLine(car.CarDescription);
            }

            carManager.Delete(new Car { CarId = 7 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
            }
        }
    }
}
