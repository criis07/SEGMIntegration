using lafise.test.Application.Todo.Commands.v1;
using FluentAssertions;
using FluentValidation;
using NUnit.Framework;

namespace Application.IntegrationTests.Todo.Commands
{
    using static Testing;

    public class UpdateTodoTodoTest
    {
        [Test]
        public async Task ShouldUpdateTodo()
        {
            var command = new UpdateTodoCommand
            {
                Description = "This is the todo test updated",
                Name = "TodoUpdt",
                Version = 2,
                Id = 1
            };

            var response = await SendAsync(command);

            response.Id.Should().Be(1);
            response.Name.Should().Be("TodoUpdt");
            response.Description.Should().Be("This is the todo test updated");
            response.Version.Should().Be(2);
        }

        [Test]
        public async Task ShouldRequireTodoId()
        {
            var command = new UpdateTodoCommand
            {
                Description = "This is the description updated",
                Name = "TodoTest",
                Version = 1,
                Id = 0
            };

            await FluentActions.Invoking(() => SendAsync(command))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}
