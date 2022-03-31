using FluentValidation;
using static CarProject.CarOperations.GetCars.GetByIdQuery;

namespace CarProject.CarOperations.GetCars
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(query=>query.CarId).GreaterThan(0).NotEmpty();
        }
    }
}
