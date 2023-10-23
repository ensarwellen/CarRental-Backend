using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId=1, DailyPrice=5000, ModelYear=2005, Description="Honda" },
                new Car { Id = 2, BrandId = 1, ColorId=2, DailyPrice=10000, ModelYear=2010, Description="Honda" },
                new Car { Id = 3, BrandId = 2, ColorId=2, DailyPrice=12000, ModelYear=2011, Description="Opel" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetail> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToDelete.BrandId = car.BrandId;
            carToDelete.ColorId = car.ColorId;
            carToDelete.DailyPrice = car.DailyPrice;
            carToDelete.ModelYear = car.ModelYear;
            carToDelete.Description = car.Description;
        }

        public List<CarDetail> GetCarDetailsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetail> GetCarDetailsByColor(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
