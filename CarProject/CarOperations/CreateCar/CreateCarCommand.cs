using CarProject.DbOperations;
using CarProject.Entity.Concrete;

namespace CarProject.CarOperations
{
    public class CreateCarCommand
    {
        public CreateCarModel Model { get; set; }
        private readonly CarStoreDbContext _context;
        public CreateCarCommand(CarStoreDbContext context )
        {
            _context = context;
        }

        public void Hande()
        {
            var newCar = new Car();

            newCar.BrandName =Model.BrandName;
            newCar.ColorName =Model.ColorName;
            newCar.ModelYear = Model.ModelYear;
            newCar.Price =Model.Price;
            newCar.MotorType =Model.MotorType;

            _context.Cars.Add(newCar);
            _context.SaveChanges();
        }
    }

    public class CreateCarModel
    {
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
        public string? MotorType { get; set; }
    }
}
