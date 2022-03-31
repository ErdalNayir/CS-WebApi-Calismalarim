using FluentValidation;

namespace CarProject.CarOperations.CreateCar
{
    public class CreateCarValidatorCommand : AbstractValidator<CreateCarCommand>
    {
        public CreateCarValidatorCommand()
        {
            RuleFor(command => command.Model.Price).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.ModelYear).NotEmpty().LessThan(DateTime.Now.Year);
            RuleFor(command => command.Model.BrandName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.ColorName).NotEmpty().MinimumLength(5);
            RuleFor(command=> command.Model.MotorType).NotEmpty().MinimumLength(5).MaximumLength(10);
        }
    }
}
