﻿using Library.Domain.Enums;

namespace Library.Application.Dto.Books
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public Genre Genre { get; set; }
    }
}
