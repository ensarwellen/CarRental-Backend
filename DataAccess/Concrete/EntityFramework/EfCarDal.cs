using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetail> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             select new CarDetail { BrandName = b.Name, CarName = b.Name, ColorName = col.Name, DailyPrice = c.DailyPrice , ModelYear = c.ModelYear,
                             Description=c.Description, CarId=c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == c.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public List<CarDetail> GetCarDetailsByBrand(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             where car.BrandId == brandId
                             select new CarDetail
                             {
                                 CarName = brand.Name,
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.ToList();
            }
        }
        public List<CarDetail> GetCarDetailsByColor(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             where car.ColorId == colorId
                             select new CarDetail
                             {
                                 CarName = brand.Name,
                                 CarId = car.Id,
                                 BrandId = brand.Id,
                                 ColorId = color.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == car.Id
                                              select img.ImagePath).FirstOrDefault()

                             };
                return result.ToList();
            }
        }
        public CarDetail GetCarById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join col in context.Colors
                             on c.ColorId equals col.Id
                             where c.Id == carId
                             select new CarDetail
                             {
                                 BrandName = b.Name,
                                 CarName = b.Name,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = col.Id,
                                 ImagePath = (from img in context.CarImages
                                              where img.CarId == c.Id
                                              select img.ImagePath).FirstOrDefault()
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
