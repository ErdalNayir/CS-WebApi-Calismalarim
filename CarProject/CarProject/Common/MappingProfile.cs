using AutoMapper;
using CarProject.CarOperations;
using CarProject.CarOperations.GetCars;
using CarProject.Entity.Concrete;
using static CarProject.CarOperations.GetCars.GetByIdQuery;

namespace CarProject.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarModel, Car>();
            CreateMap<Car, CarViewModel>();
            CreateMap<Car, CarsViewModel>();
        }

        
    }
}
