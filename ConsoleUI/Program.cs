using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CustomerManager customerManager = new CustomerManager(new  EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Entities.Concrete.Rental { Id = 1, CarId = 1, UserId = 5, RentDate = new DateTime(2023, 09, 27), ReturnDate = new DateTime(2023, 09, 29) });
            //customerManager.Add(new Entities.Concrete.Customer { Id=1,UserId = 1, CompanyName = "Toska" });
            var musteriGetir = customerManager.GetAll();
            if (musteriGetir.Success)
            {
                foreach (var item in musteriGetir.Data)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
            
            //EfCarDal car = new EfCarDal();
            //car.Delete(new Entities.Concrete.Car { Id = 1, ColorId = 1, BrandId = 1, DailyPrice = 500, ModelYear = "2017", Description = "Honda" });
            //car.Delete(new Entities.Concrete.Car { Id = 2, ColorId = 1, BrandId = 2, DailyPrice = 400, ModelYear = "2016", Description = "BMW" });
            //car.Delete(new Entities.Concrete.Car { Id = 3, ColorId = 2, BrandId = 1, DailyPrice = 300, ModelYear = "2015", Description = "Honda" });
            //car.Add(new Entities.Concrete.Car { Id = 1, ColorId = 1, BrandId = 1, DailyPrice = 500, ModelYear = 2017, Description = "Honda" });
            var result = carManager.GetCarDetail();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CarName+" "+item.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.Description);
            //}


            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);

            //}
        }
    }
}