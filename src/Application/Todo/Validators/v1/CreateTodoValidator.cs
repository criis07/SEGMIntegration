using lafise.test.Application.Todo.Commands.v1;
using FluentValidation;

namespace lafise.test.Application.Todo.Validators.v1
{
    public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoValidator()
        {
            RuleFor(ct => ct.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(ct => ct.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
        }
    }
}