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

        // ��������� ����������� ��� Singleton
        private Library() { }

        // �������� ��� ��������� ������������� ���������� (Singleton)
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

        // ���������� ����� � ����������
        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            books.Add(book);
        }

        // �������� ����� �� ����������
        public void RemoveBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            books.Remove(book);
        }

        // ����� ���� �� ��������
        public List<Book> FindBooksByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return new List<Book>();
            return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // ����� ���� �� ������
        public List<Book> FindBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author)) return new List<Book>();
            return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // ����������� ������������
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
