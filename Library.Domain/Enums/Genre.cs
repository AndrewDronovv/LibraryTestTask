using System.ComponentModel;

namespace Library.Domain.Enums
{
    public enum Genre
    {
        [Description("Фантастика")]
        Fiction,
        
        [Description("Роман")]
        Romance,

        [Description("Классика")]
        Classic,

        [Description("Приключение")]
        Adventure
    }
}
