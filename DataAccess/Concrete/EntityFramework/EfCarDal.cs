using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NewdbContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (NewdbContext context = new NewdbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.CarBrandId equals b.BrandId
                             join co in context.Colors
                             on c.CarColorId equals co.ColorId
                             select new CarDetailDTO { CarId = c.CarId, CarName = c.CarDescription, BrandName = b.BrandName, ColorName = co.ColorName };
                return result.ToList();
            }
        }

        
    }
}
