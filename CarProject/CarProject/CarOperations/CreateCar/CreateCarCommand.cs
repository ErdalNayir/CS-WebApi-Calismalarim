using AutoMapper;
using CarProject.DbOperations;
using CarProject.Entity.Concrete;

namespace CarProject.CarOperations
{
    public class CreateCarCommand
    {
        public CreateCarModel Model { get; set; }
        private readonly CarStoreDbContext _context;

        private readonly IMapper _mapper;
        public CreateCarCommand(CarStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Hande()
        {
            var newCar = _mapper.Map<Car>(Model); 
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
