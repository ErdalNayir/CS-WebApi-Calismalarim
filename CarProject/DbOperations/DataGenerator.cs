using CarProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CarProject.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CarStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<CarStoreDbContext>>()))
            {
                if(context.Cars.Any()) //hiç veri varsa
                {
                    return;
                }

                context.Cars.AddRange
                (
                    new Car {BrandName = "Toyota", ColorName = "Yellow", ModelYear = 2001, Price = 45000, MotorType = "Diasel" },
                    new Car {BrandName = "Hyundai", ColorName = "Grey", ModelYear = 2011, Price = 150000, MotorType = "Hybrid" },
                    new Car {BrandName = "Nissan", ColorName = "White", ModelYear = 2021, Price = 250000, MotorType = "Electric" },
                    new Car {BrandName = "Fiat", ColorName = "Black", ModelYear = 2020, Price = 225000, MotorType = "Gas" },
                    new Car {BrandName = "Volvo", ColorName = "Blue", ModelYear = 2022, Price = 300000, MotorType = "Electric" }
                );

                context.SaveChanges();
            }
        }
       
    }
}
