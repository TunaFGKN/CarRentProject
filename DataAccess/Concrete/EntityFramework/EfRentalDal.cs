using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NewdbContext>, IRentalDal
    {
        public List<RentCarDetailDto> GetRentDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (NewdbContext context = new NewdbContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join u in context.Users on cu.UserId equals u.UserId
                             select new RentCarDetailDto
                             {
                                 CarName = c.CarDescription,
                                 CompanyName = cu.CompanyName,
                                 CustomerName = u.FirstName + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };
                return result.ToList();
            }
        }    
    }
}
