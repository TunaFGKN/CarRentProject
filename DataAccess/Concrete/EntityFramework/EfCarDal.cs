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
        public void Add(Car entity)
        {
            using (NewdbContext context = new NewdbContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (NewdbContext context = new NewdbContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (NewdbContext context = new NewdbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (NewdbContext context = new NewdbContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (NewdbContext context = new NewdbContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

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
