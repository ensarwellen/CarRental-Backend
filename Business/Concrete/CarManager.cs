using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Results.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IDataResult<Car> Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessDataResult<Car>(_carDal.GetById(c=>c.Id==car.Id),Messages.Added);
        }
        public IDataResult<Car> Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == car.Id), Messages.Updated);
        }
        public IDataResult<Car> Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == car.Id), Messages.Updated);
        }

        //[CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 7)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<CarDetail> GetById(int carId)
        {
            return new SuccessDataResult<CarDetail>(_carDal.GetCarById(carId));
        }

        public IDataResult<List<CarDetail>> GetCarDetail()
        {
            if (DateTime.Now.Hour == 7)
            {
                return new ErrorDataResult<List<CarDetail>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetail>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetCarDetailsByBrand(brandId));
        }

        public IDataResult<List<CarDetail>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetCarDetailsByColor(colorId));
        }
        public IDataResult<List<CarDetail>> GetCarDetailsByColorAndBrand(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetail>>(
               _carDal.GetCarDetails()
               .Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }
    }
}
