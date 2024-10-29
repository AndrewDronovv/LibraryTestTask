using Library.Domain.Common;
using Library.Domain.Enums;

namespace Library.Domain.Entities
{
    public class Book : Entity
    {
        //[Required]
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Заголовок должен содержать только буквы и пробелы")]
        public string Title { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "AuthorId должен быть положительным")]

        public int AuthorId { get; set; }
        //[JsonIgnore]
        public Author? Author { get; set; }


        //[Range(1600, 2024)]
        public int PublishedYear { get; set; }
        //[Required]
        public Genre Genre { get; set; }
    }
}