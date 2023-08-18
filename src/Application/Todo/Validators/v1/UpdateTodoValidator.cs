using lafise.test.Application.Todo.Commands.v1;
using FluentValidation;

namespace lafise.test.Application.Todo.Validators.v1
{
    public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
    {
        public UpdateTodoValidator()
        {
            RuleFor(ct => ct.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(ct => ct.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(ct => ct.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}