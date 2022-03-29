using CarProject.DbOperations;
using CarProject.Entity.Concrete;

namespace CarProject.CarOperations.GetCars
{
    public class GetCarsQuery
    {
        private readonly CarStoreDbContext _context;
        public GetCarsQuery(CarStoreDbContext context)
        {
            _context = context;
        }

        public List<CarsViewModel> Handle()
        {
            var carList=_context.Cars.OrderBy(x=>x.Id).ToList<Car>();
            List<CarsViewModel> vm = new List<CarsViewModel>();

            foreach (var car in carList)
            {
                vm.Add(
                    new CarsViewModel()
                    {
                        BrandName = car.BrandName,
                        ColorName = car.ColorName,
                        ModelYear = car.ModelYear,
                        MotorType = car.MotorType,
                        Price = car.Price,
                    }
                );

            }
            return vm;
        }
    }

    public class CarsViewModel
    {
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
        public string? MotorType { get; set; }
    }
}
