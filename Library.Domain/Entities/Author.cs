using Library.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        [NotMapped]
        public string FullName => $"{Name} {Surname}";
        public DateOnly Birthday { get; set; }
    }
}