using FluentValidation;

namespace CleanArchitecture.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(v => v.Text)
                .NotEmpty();
        }
    }
}
