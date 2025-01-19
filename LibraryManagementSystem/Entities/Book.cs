namespace LibraryManagementSystem.Entities
{
    public partial class Book
    {
        // �������� �����
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public int YearPublished { get; private set; }
        public string Genre { get; private set; }
        public bool IsBorrowed { get; private set; }

        // �����������, ���������� ����� Builder
        private Book(BookBuilder builder)
        {
            Title = builder.Title;
            Author = builder.Author;
            ISBN = builder.ISBN;
            Publisher = builder.Publisher;
            YearPublished = builder.YearPublished;
            Genre = builder.Genre;
            IsBorrowed = false; // ���������� ����� �� ������
        }

        // ������ ���������� �������� �����
        public void Borrow()
        {
            if (IsBorrowed)
            {
                throw new InvalidOperationException("This book is already borrowed.");
            }
            IsBorrowed = true;
        }

        public void ReturnBook()
        {
            if (!IsBorrowed)
            {
                throw new InvalidOperationException("This book is not borrowed.");
            }
            IsBorrowed = false;
        }
    }
}
