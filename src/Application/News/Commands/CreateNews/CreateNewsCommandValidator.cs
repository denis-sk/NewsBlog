using FluentValidation;

namespace CleanArchitecture.Application.News.Commands.CreateNews
{
    public class CreateNewsItemCommandValidator : AbstractValidator<CreateNewsItemCommand>
    {
        public CreateNewsItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(255)
                .NotEmpty();
        }
    }
}
