// See https://aka.ms/new-console-template for more information
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;




//carService.AddCar(new Car { BrandId = 2, ColorId = 1, DailyPrice = 260, ModelYear = new DateTime(2021,01,01), Description = "BMW araci 3" });
//carService.DeleteCar(carService.GetByCarId(1003));

//Car updatedCar = carService.GetByCarId(1002);
//updatedCar.DailyPrice = 320;
//carService.UpdateCar(updatedCar);



//CarTest();
//ColorTest();
//BrandTest();

/*
ICarService carService = new CarManager(new EfCarDal());

foreach (CarDetailDto car in carService.GetCarDetails())
{
    Console.WriteLine("ID: " + car.CarId + " BRAND: " + car.Brand+ " MODEL: " + car.Model + " COLOR: " + car.Color + " MODEL YEAR: " + car.ModelYear.Year + " DAILY PRICE: " + car.DailyPrice + " DESCRIPTION: " + car.Description + "\n");
}

IModelService modelService = new ModelManager(new EfModelDal());

foreach(ModelDetailDto model in modelService.GetModelDetails())
{
    Console.WriteLine("MODEL ID: "+model.ModelId+" BRAND NAME: "+model.BrandName+" MODEL NAME: "+model.ModelName+"\n");
}


static void BrandTest()
{
    IBrandService brandService = new BrandManager(new EfBrandDal());

    Console.WriteLine("BRANDS\n");

    foreach (Brand brand in brandService.GetAll())
    {
        Console.WriteLine("ID: " + brand.Id + " BRAND NAME: " + brand.BrandName + "\n");
    }
}

static void ColorTest()
{
    IColorService colorService = new ColorManager(new EfColorDal());

    Console.WriteLine("COLORS\n");

    foreach (Color color in colorService.GetAll())
    {
        Console.WriteLine("ID: " + color.Id + " COLOR NAME: " + color.ColorName + "\n");
    }
}

static void CarTest()
{
    ICarService carService = new CarManager(new EfCarDal());

    Console.WriteLine("CARS\n");
    foreach (Car car in carService.GetAll())
    {
        Console.WriteLine("ID: " + car.Id + " BRAND ID: " + car.BrandId + " COLOR ID: " + car.ColorId + " MODEL YEAR: " + car.ModelYear.Year + " DAILY PRICE: " + car.DailyPrice + " DESCRIPTION: " + car.Description + "\n");

    }
}
*/

Console.WriteLine("asda");