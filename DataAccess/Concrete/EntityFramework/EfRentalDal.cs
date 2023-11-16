using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDto> getRentalDatesByCarId(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var rentalInfos = context.Rentals
            .Where(r => r.CarId == carId)
            .Select(r => new RentalDto
            {
                RentDate = r.RentDate,
                ReturnDate = r.ReturnDate
            })
            .ToList();

                return rentalInfos;
            }
        }
    }
}
