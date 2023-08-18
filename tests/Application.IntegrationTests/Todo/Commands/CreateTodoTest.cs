using lafise.test.Application.Todo.Commands.v1;
using FluentAssertions;
using FluentValidation;
using NUnit.Framework;

namespace Application.IntegrationTests.Todo.Commands
{
    using static Testing;

    public class CreateTodoTest
    {
        [Test]
        public async Task ShouldCreateTodo()
        {
            var command = new CreateTodoCommand
            {
                Description = "This is the todo test",
                Name = "TodoTest",
                Version = 1
            };

            var response = await SendAsync(command);

            response.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task ShouldRequireNotEmptyDescription()
        {
            var command = new CreateTodoCommand
            {
                Description = "",
                Name = "TodoTest",
                Version = 1
            };

            await FluentActions.Invoking(() => SendAsync(command))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}
