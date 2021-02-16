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
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { Id = 1, FirstName = "Tuna", LastName = "Figankaplan", Email = "tf@gmail.com", Password = "1234tf" });
            userManager.Add(new User { Id = 2, FirstName = "Demirkan", LastName = "Bakar", Email = "db@gmail.com", Password = "1234db" });
            userManager.Add(new User { Id = 1, FirstName = "Engin", LastName = "Demiroğ", Email = "ed@gmail.com", Password = "1234ed" });
            // CarTest();
            // ColorTest();
            // BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());           
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
