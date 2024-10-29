using Library.Domain.Enums;

namespace Library.WebpApi.Dto.Genres
{
    public sealed class GenresDto
    {
        public string Name { get; set; }
        public Genre Value { get; set; }
    }
}