using FluentValidation;

namespace CleanArchitecture.Application.News.Commands.UpdateNews
{
    public class UpdateNewsItemCommandValidator : AbstractValidator<UpdateNewsItemCommand>
    {
        public UpdateNewsItemCommandValidator()
        {
            RuleFor(v => v.Title)
                .MaximumLength(255)
                .NotEmpty();
        }
    }
}
