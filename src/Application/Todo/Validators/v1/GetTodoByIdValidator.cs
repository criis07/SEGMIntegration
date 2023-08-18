using lafise.test.Application.Todo.Queries.v1;
using FluentValidation;

namespace lafise.test.Application.Todo.Validators.v1
{
    public class GetTodoByIdValidator : AbstractValidator<GetTodoByIdQuery>
    {
        public GetTodoByIdValidator()
        {
            RuleFor(ct => ct.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}