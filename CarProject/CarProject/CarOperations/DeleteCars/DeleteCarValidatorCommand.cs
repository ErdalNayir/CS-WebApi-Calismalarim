using FluentValidation;

namespace CarProject.CarOperations.DeleteCars
{
    public class DeleteCarValidatorCommand : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarValidatorCommand()
        {
            RuleFor(command => command.CarId).GreaterThan(0).NotEmpty();
        }
    }
}
