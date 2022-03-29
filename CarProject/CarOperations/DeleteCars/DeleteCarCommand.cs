using CarProject.DbOperations;

namespace CarProject.CarOperations.DeleteCars
{
    public class DeleteCarCommand
    {
        public int CarId { get; set; }
        private readonly CarStoreDbContext _context;
        public DeleteCarCommand(CarStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var car=_context.Cars.SingleOrDefault(x=>x.Id==CarId);

            if(car is null)
            {
                throw new InvalidOperationException("Böyle bir ıd'ye sahip araç yok");
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}
