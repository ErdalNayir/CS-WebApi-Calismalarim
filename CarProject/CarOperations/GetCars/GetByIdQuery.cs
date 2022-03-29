using CarProject.DbOperations;
using Microsoft.AspNetCore.Mvc;

namespace CarProject.CarOperations.GetCars
{
    public class GetByIdQuery
    {
        private readonly CarStoreDbContext _context;

        public int CarId { get; set; }
        public GetByIdQuery(CarStoreDbContext context)
        {
            _context = context;
        }

        public CarViewModel Handle()
        {
            var car= _context.Cars.SingleOrDefault(c => c.Id == CarId);

            var result = new CarViewModel()
            {
                BrandName = car.BrandName,
                ColorName = car.ColorName,
                Price = car.Price,
                ModelYear = car.ModelYear,
                MotorType = car.MotorType,
            };

            return result;
            
        }

        public class CarViewModel
        {
            public string? BrandName { get; set; }
            public string? ColorName { get; set; }
            public int ModelYear { get; set; }
            public int Price { get; set; }
            public string? MotorType { get; set; }
        }
    }
}
