using AutoMapper;
using CarProject.CarOperations;
using CarProject.CarOperations.CreateCar;
using CarProject.CarOperations.DeleteCars;
using CarProject.CarOperations.GetCars;
using CarProject.CarOperations.UpdateCars;
using CarProject.DbOperations;
using CarProject.Entity.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static CarProject.CarOperations.UpdateCars.UpdateCarCommand;

namespace CarProject.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CarController : ControllerBase
    {
        /*
        private static List<Car> cars = new List<Car>() 
        {
            new Car {Id=1,BrandName = "Toyota",ColorName ="Yellow",ModelYear =2001,Price =45000,MotorType ="Diasel"},
            new Car {Id=2,BrandName = "Hyundai",ColorName ="Grey",ModelYear =2011,Price =150000,MotorType ="Hybrid"},
            new Car {Id=3,BrandName = "Nissan",ColorName ="White",ModelYear =2021,Price =250000,MotorType ="Electric"},
            new Car {Id=4,BrandName = "Fiat",ColorName ="Black",ModelYear =2020,Price =225000,MotorType ="Gas"},
            new Car {Id=5,BrandName = "Volvo",ColorName ="Blue",ModelYear =2022,Price =300000,MotorType ="Electric"},

        
        
        };
        */
        private readonly CarStoreDbContext _context;
        private readonly IMapper _mapper;

        public CarController(CarStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] 
        public IActionResult GetBooks()
        {
            GetCarsQuery query = new GetCarsQuery(_context,_mapper);
            var result = query.Handle();

            if(result is null)
            {
                return BadRequest(result);
            }

            return Ok(result);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            GetByIdQuery query = new GetByIdQuery(_context,_mapper);

            try
            {
                GetByIdQueryValidator validator = new GetByIdQueryValidator();
                query.CarId = id;
                validator.ValidateAndThrow(query);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var result = query.Handle();

            if(result is null)
            {
                return BadRequest("Database is Empty");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCar(CreateCarModel newBook) 
        {
            CreateCarCommand command = new CreateCarCommand(_context,_mapper);


            try
            {
                command.Model = newBook;

                CreateCarValidatorCommand validator = new CreateCarValidatorCommand();
                validator.ValidateAndThrow(command);


               command.Hande();
            }
            catch (Exception ex)
            {
                return BadRequest("Hatalı İşlem");
            }
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateCar(int id,UpdateCarModel updateCar)
        {
           

            UpdateCarCommand command = new UpdateCarCommand(_context);


            

            try
            {
                UpdateCarValidatorCommand validator = new UpdateCarValidatorCommand();
                command.CarId = id;
                command.Model = updateCar;

                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
           
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            DeleteCarCommand command = new DeleteCarCommand(_context);

            try
            {
                DeleteCarValidatorCommand validator = new DeleteCarValidatorCommand();
                command.CarId = id;
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

    }
}
