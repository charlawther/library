using System;
using System.Collections.Generic;

class Program
{
    // Сущности
    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class IssuedBook
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime IssueDate { get; set; }
    }

    class ReturnedBook
    {
        public Book Book { get; set; }
        public Reader Reader { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    // Хранилища данных
    static List<Book> books = new List<Book>();
    static List<Reader> readers = new List<Reader>();
    static List<IssuedBook> issuedBooks = new List<IssuedBook>();
    static List<ReturnedBook> returnedBooks = new List<ReturnedBook>();

    // Методы для добавления книг и читателей
    static void AddBook(int id, string title, string author)
    {
        books.Add(new Book { Id = id, Title = title, Author = author });
        Console.WriteLine("Книга добавлена.");
    }

    static void AddReader(int id, string name)
    {
        readers.Add(new Reader { Id = id, Name = name });
        Console.WriteLine("Читатель добавлен.");
    }

    // Метод для выдачи книги
    static void IssueBook(int bookId, int readerId)
    {
        Book book = books.Find(b => b.Id == bookId);
        Reader reader = readers.Find(r => r.Id == readerId);

        if (book != null && reader != null)
        {
            issuedBooks.Add(new IssuedBook { Book = book, Reader = reader, IssueDate = DateTime.Now });
            Console.WriteLine("Книга выдана.");
        }
        else
        {
            Console.WriteLine("Книга или читатель не найдены.");
        }
    }

    // Метод для возврата книги
    static void ReturnBook(int bookId, int readerId)
    {
        IssuedBook issuedBook = issuedBooks.Find(ib => ib.Book.Id == bookId && ib.Reader.Id == readerId);

        if (issuedBook != null)
        {
            issuedBooks.Remove(issuedBook);
            returnedBooks.Add(new ReturnedBook { Book = issuedBook.Book, Reader = issuedBook.Reader, ReturnDate = DateTime.Now });
            Console.WriteLine("Книга возвращена.");
        }
        else
        {
            Console.WriteLine("Выдача книги не найдена.");
        }
    }

    // Метод для получения информации о книге (структурированный вывод)
    static void GetBookInfo(int bookId)
    {
        Book book = books.Find(b => b.Id == bookId);
        if (book != null)
        {
            Console.WriteLine("Информация о книге:");
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", "ID", "Название", "Автор");
            Console.WriteLine(new string('-', 65));
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", book.Id, book.Title, book.Author);
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }

    // Метод для получения информации о читателе (структурированный вывод)
    static void GetReaderInfo(int readerId)
    {
        Reader reader = readers.Find(r => r.Id == readerId);
        if (reader != null)
        {
            Console.WriteLine("Информация о читателе:");
            Console.WriteLine("{0,-10} | {1,-20}", "ID", "Имя");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("{0,-10} | {1,-20}", reader.Id, reader.Name);
        }
        else
        {
            Console.WriteLine("Читатель не найден.");
        }
    }

    // Метод для получения информации о всех выданных книгах
    static void GetIssuedBooksInfo()
    {
        Console.WriteLine("Выданные книги:");
        Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", "ID книги", "Название книги", "Читатель", "Дата выдачи");
        Console.WriteLine(new string('-', 85));
        foreach (var issuedBook in issuedBooks)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", issuedBook.Book.Id, issuedBook.Book.Title, issuedBook.Reader.Name, issuedBook.IssueDate.ToShortDateString());
        }
    }

    // Метод для получения информации о всех возвращенных книгах
    static void GetReturnedBooksInfo()
    {
        Console.WriteLine("Возвращенные книги:");
        Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", "ID книги", "Название книги", "Читатель", "Дата возврата");
        Console.WriteLine(new string('-', 85));
        foreach (var returnedBook in returnedBooks)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", returnedBook.Book.Id, returnedBook.Book.Title, returnedBook.Reader.Name, returnedBook.ReturnDate.ToShortDateString());
        }
    }

    static void Main(string[] args)
    {
        // Пример использования программы
        AddBook(1, "Война и мир", "Лев Толстой");
        AddBook(2, "Преступление и наказание", "Федор Достоевский");
        AddReader(1, "Иван Иванов");
        AddReader(2, "Анна Петрова");

        IssueBook(1, 1); // Выдать книгу
        IssueBook(2, 2); // Выдать книгу
        ReturnBook(1, 1); // Вернуть книгу

        Console.WriteLine();
        GetBookInfo(1); // Получить информацию о книге
        Console.WriteLine();
        GetReaderInfo(1); // Получить информацию о читателе
        Console.WriteLine();
        GetIssuedBooksInfo(); // Получить информацию о всех выданных книгах
        Console.WriteLine();
        GetReturnedBooksInfo(); // Получить информацию о всех возвращенных книгах
    }
}
