using API.EntityLayer.Concrete;
using FluentValidation;

namespace API.Consume.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title alani bos gecilemez.");
        }
    }
}
