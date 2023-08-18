using lafise.test.Application.Todo.Commands.v1;
using FluentValidation;

namespace lafise.test.Application.Todo.Validators.v1
{
    public class DeleteTodoValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoValidator()
        {
            RuleFor(ct => ct.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}