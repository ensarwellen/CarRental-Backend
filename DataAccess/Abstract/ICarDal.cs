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
        List<CarDetail> GetCarDetailsByBrand(int brandId);
        List<CarDetail> GetCarDetailsByColor(int colorId);
    }
}
