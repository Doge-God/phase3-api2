using FluentValidation;

namespace phase3_api2.Domain.DTO
{
    public class TakeProdDto
    {
        public int Id { get; set; }

        public bool isWasted { get; set; }
    }

    public class TakeProdDtoValidator : AbstractValidator<TakeProdDto>
    {
        public TakeProdDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not be empty");
            RuleFor(x => x.isWasted).NotEmpty().WithMessage("isWasted must not be empty");
        }
    }
}

