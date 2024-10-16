## Описание

Данный проект представляет собой простую программу для учета книг в библиотеке. Программа написана на языке C# без использования базы данных — все данные хранятся в коллекциях в памяти программы. Основные функции системы включают добавление книг и читателей, учет выдачи и возврата книг, а также получение информации о книгах и читателях.

Программа состоит из следующих основных сущностей:

1. **Book** — класс для представления книги.
2. **Reader** — класс для представления читателя.
3. **IssuedBook** — класс для учета выданных книг.
4. **ReturnedBook** — класс для учета возвращенных книг.

## Функциональность

Программа поддерживает следующие операции:

1. **Добавление книг и читателей:**
   - `AddBook(int id, string title, string author)` — добавляет новую книгу в коллекцию.
   - `AddReader(int id, string name)` — добавляет нового читателя.

2. **Выдача и возврат книг:**
   - `IssueBook(int bookId, int readerId)` — выдает книгу читателю, добавляя запись в коллекцию выданных книг.
   - `ReturnBook(int bookId, int readerId)` — возвращает книгу от читателя, перемещая запись в коллекцию возвращенных книг.

3. **Получение информации:**
   - `GetBookInfo(int bookId)` — выводит информацию о книге в виде таблицы.
   - `GetReaderInfo(int readerId)` — выводит информацию о читателе в виде таблицы.
   - `GetIssuedBooksInfo()` — выводит информацию о всех выданных книгах.
   - `GetReturnedBooksInfo()` — выводит информацию о всех возвращенных книгах.


### Пример вывода данных:
<img width="728" alt="image" src="https://github.com/user-attachments/assets/545947a2-a5b2-4ce0-93bd-0b1723a00b34">


