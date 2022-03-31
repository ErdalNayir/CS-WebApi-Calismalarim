using FluentValidation;

namespace CarProject.CarOperations.UpdateCars
{
    public class UpdateCarValidatorCommand : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarValidatorCommand()
        {
            RuleFor(command=>command.Model.Price).NotEmpty().GreaterThan(1000);
            RuleFor(command => command.Model.ModelYear).NotEmpty().LessThan(DateTime.Now.Year);
            RuleFor(command => command.Model.MotorType).NotEmpty().MaximumLength(10);
            RuleFor(command => command.Model.ColorName).NotEmpty().MaximumLength(8);
            RuleFor(command => command.Model.BrandName).NotEmpty().MaximumLength(10);
            RuleFor(command => command.CarId).GreaterThan(0).NotEmpty();

        }
    }
}
