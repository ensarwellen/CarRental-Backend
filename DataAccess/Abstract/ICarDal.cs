using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetail> GetCarDetails();
        List<CarDetail> GetCarDetailsByBrand(int brandId, int page);
        List<CarDetail> GetCarDetailsByColor(int colorId, int page);
        CarDetail GetCarById(int carId);
        List<CarDetail> getCarsWithPagination(int page);
    }
}
