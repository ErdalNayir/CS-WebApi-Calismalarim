using AutoMapper;
using CarProject.DbOperations;
using CarProject.Entity.Concrete;

namespace CarProject.CarOperations.GetCars
{
    public class GetCarsQuery
    {
        private readonly CarStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetCarsQuery(CarStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CarsViewModel> Handle()
        {
            var carList=_context.Cars.OrderBy(x=>x.Id).ToList<Car>();
            List<CarsViewModel> vm =_mapper.Map<List<CarsViewModel>>(carList);
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
