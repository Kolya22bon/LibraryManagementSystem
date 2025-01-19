using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Entities
{
    public class User
    {
        public string Name { get; private set; }
        public List<Book> BorrowedBooks { get; private set; } = new List<Book>();

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            Name = name;
        }

        // Взять книгу
        public void BorrowBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (book.IsBorrowed)
            {
                throw new InvalidOperationException("This book is already borrowed.");
            }
            book.Borrow();
            BorrowedBooks.Add(book);
        }

        // Вернуть книгу
        public void ReturnBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (!BorrowedBooks.Contains(book))
            {
                throw new InvalidOperationException("This book was not borrowed by the user.");
            }
            book.ReturnBook();
            BorrowedBooks.Remove(book);
        }
    }
}
