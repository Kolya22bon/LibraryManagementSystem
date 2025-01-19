namespace LibraryManagementSystem.Entities
{
    public partial class Book
    {
        public class BookBuilder
        {
            // Поля для настройки книги
            public string Title { get; private set; }
            public string Author { get; private set; }
            public string ISBN { get; private set; }
            public string Publisher { get; private set; }
            public int YearPublished { get; private set; }
            public string Genre { get; private set; }

            // Конструктор с обязательными параметрами
            public BookBuilder(string title, string author)
            {
                Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null");
                Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null");
            }

            // Методы для настройки дополнительных параметров
            public BookBuilder WithISBN(string isbn)
            {
                ISBN = isbn;
                return this;
            }

            public BookBuilder WithPublisher(string publisher)
            {
                Publisher = publisher;
                return this;
            }

            public BookBuilder WithYearPublished(int year)
            {
                YearPublished = year;
                return this;
            }

            public BookBuilder WithGenre(string genre)
            {
                Genre = genre;
                return this;
            }

            // Метод для создания экземпляра Book
            public Book Build()
            {
                return new Book(this);
            }
        }
    }
}
