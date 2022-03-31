using AutoMapper;
using CarProject.DbOperations;
using Microsoft.AspNetCore.Mvc;

namespace CarProject.CarOperations.GetCars
{
    public class GetByIdQuery
    {
        private readonly CarStoreDbContext _context;
        private readonly IMapper _mapper;

        public int CarId { get; set; }
        public GetByIdQuery(CarStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CarViewModel Handle()
        {
            var car= _context.Cars.SingleOrDefault(c => c.Id == CarId);

            var result = _mapper.Map<CarViewModel>(car);
        
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
