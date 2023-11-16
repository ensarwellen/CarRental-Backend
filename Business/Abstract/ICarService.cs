using Core.Results.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetail>> GetCarsByBrandId(int brandId, int page);
        IDataResult<List<CarDetail>> GetCarsByColorId(int colorId,int page);
        IDataResult<CarDetail> GetById(int carId);
        IDataResult<List<CarDetail>> GetCarDetail();
        IDataResult<List<CarDetail>> GetCarsWithPagination(int page);
        IDataResult<Car> Add(Car car);
        IDataResult<Car> Update(Car car);
        IDataResult<Car> Delete(Car car);
        IDataResult<List<CarDetail>> GetCarDetailsByColorAndBrand(int brandId, int colorId);
    }
}
