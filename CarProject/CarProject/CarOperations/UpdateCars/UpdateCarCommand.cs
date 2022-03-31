using CarProject.DbOperations;

namespace CarProject.CarOperations.UpdateCars
{
    public class UpdateCarCommand
    {
        public UpdateCarModel Model { get; set; }
        public int CarId { get; set; }
        public readonly CarStoreDbContext _context;

        public UpdateCarCommand(CarStoreDbContext context)
        {            
            _context = context;
        }

        public void Handle()
        {
            var updatedCar=_context.Cars.SingleOrDefault(x=> x.Id == CarId);
            if(updatedCar is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            updatedCar.ModelYear = Model.ModelYear != default ? Model.ModelYear : Model.ModelYear;
            updatedCar.Price = Model.Price != default ? Model.Price : Model.Price;
            updatedCar.ColorName = Model.ColorName != default ? Model.ColorName : Model.ColorName;
            updatedCar.MotorType = Model.MotorType != default ? Model.MotorType : Model.MotorType;
            updatedCar.BrandName = Model.BrandName != default ? Model.BrandName : Model.BrandName;

            _context.SaveChanges();
        }

        public class UpdateCarModel
        {
            public string? BrandName { get; set; }
            public string? ColorName { get; set; }
            public int ModelYear { get; set; }
            public int Price { get; set; }
            public string? MotorType { get; set; }
        }
    }
}
