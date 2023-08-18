namespace lafise.test.Application.Todo.Dto.v1
{
    public record TodoDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Version { get; set; }
    }
}