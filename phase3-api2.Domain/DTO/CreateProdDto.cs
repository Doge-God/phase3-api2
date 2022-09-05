using FluentValidation;

namespace phase3_api2.Domain.DTO
{
    public class CreateProdDto
    {
        public string Name { get; set; }

        public DateTime TimeExpire { get; set; }
    }

    public class CreateProdDtoValidator : AbstractValidator<CreateProdDto>
    {
        public CreateProdDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name must not be empty.");
            RuleFor(p => p.TimeExpire).NotEmpty().WithMessage("Expire time must not be empty.");
            //RuleFor(p => p.TimeExpire.GetType()).Equal(typeof(DateTime));
        }
    }
}
