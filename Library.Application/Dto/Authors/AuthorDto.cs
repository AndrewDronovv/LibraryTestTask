namespace Library.Application.Dto.Authors
{
    public sealed class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public DateOnly Birthday { get; set; }
    }
}