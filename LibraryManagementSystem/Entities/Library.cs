using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Entities
{
    public class Library
    {
        private static Library instance = null;
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();

        // Приватный конструктор для Singleton
        private Library() { }

        // Свойство для получения единственного экземпляра (Singleton)
        public static Library Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        // Добавление книги в библиотеку
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            books.Add(book);
        }

        // Удаление книги из библиотеки
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            books.Remove(book);
        }

        // Поиск книг по названию
        public List<Book> FindBooksByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return new List<Book>();
            return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Поиск книг по автору
        public List<Book> FindBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author)) return new List<Book>();
            return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Регистрация пользователя
        public void RegisterUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (!users.Contains(user))
            {
                users.Add(user);
            }
        }
    }
}
