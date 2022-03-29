using CarProject.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarProject.Entity.Concrete
{
    public class Car:IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public int ModelYear { get; set; }
        public int Price { get; set; }
        public string? MotorType { get; set; }


    }
}
