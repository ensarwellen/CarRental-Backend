using Business.Abstract;
using Business.Constants;
using Core.Results.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal)
        {
            _rentalDal = rentaldal;
        }
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfRented(rental));
            if (result == null)
            {
                if (rental.ReturnDate != null)
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult("Araba Kiralandı.");
                }
            }
            
            return new ErrorResult("Araba Kiralanamadı");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<RentalDto>> GetRentDatesByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.getRentalDatesByCarId(carId),Messages.Listed);
        }
        private IResult CheckIfRented(Rental rental)
        {
            var rentals = _rentalDal.getRentalDatesByCarId(rental.CarId);
            foreach (var rent in rentals)
            {
                if ((rental.RentDate >= rent.RentDate && rental.RentDate < rent.ReturnDate) ||
            (rental.ReturnDate > rent.RentDate && rental.ReturnDate <= rent.ReturnDate) ||
            (rental.RentDate <= rent.RentDate && rental.ReturnDate >= rent.ReturnDate))
                {
                    // Eğer çakışma varsa, kiralama işlemini engelle
                    return new ErrorResult("Seçtiğiniz tarihler başka bir kiralama ile çakışıyor.");
                }

                // Eğer yeni kiralamanın başlangıç tarihi, mevcut kiralamanın iade tarihine eşitse veya daha küçükse,
                // aracın bir sonraki kullanılabilir tarihini kontrol et
                if (rental.RentDate == rent.ReturnDate || rental.ReturnDate == rent.RentDate)
                {
                    if (rent.ReturnDate != null)
                    {
                        return new ErrorResult("Seçtiğiniz tarihler başka bir kiralama ile çakışıyor.");
                    }
                }
            }
            return new SuccessResult();
           
        }
    }
}
