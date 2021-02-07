using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            // ColorTest();
            // BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarDescription);
            }
            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.CarDescription);
            //}
            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.CarDescription);
            //}
            //carManager.Add(new Car { CarId = 7, CarBrandId = 5, CarColorId = 1, CarDailyPrice = 1250, CarModelYear = 2016, CarDescription = "New Car" });
            //carManager.Update(new Car { CarId = 7, CarBrandId = 6, CarColorId = 2, CarDailyPrice = 1500, CarModelYear = 2016, CarDescription = "Updated new car" });
            //carManager.Delete(new Car { CarId = 7 });
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarId);
            //}

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);
            }
        }
    }
}
