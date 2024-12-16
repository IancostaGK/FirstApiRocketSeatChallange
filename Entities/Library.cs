using FirstApi.Communication.Requests;

namespace FirstApi.Entities;

public class Library
{
    static public List<Book> Books { get; set; } = new List<Book>
    {
        new("The Catcher in the Rye", "Fiction", "J.D. Salinger", 9.99f, 10, 4),
        new("To Kill a Mockingbird", "Fiction", "Harper Lee", 12.99f, 5)
    };

    public void AddBook(Book newBook)
    {
        Books.Add(newBook);
    }  
    
    public Book? getBookById(long id)
    {
        var book = Books.Find(val => val.Id == id);
        return book;
    }     
    
    public long? RemoveBook(long id)
    {
        var index = Books.FindIndex(val => val.Id == id);
        if (index != -1)
        {
            Books.RemoveAt(index);
            return id;
        }

        return null;
    }    

    public long? UpdateBook(long id, RequestCreateBook book)
    {
        var index = Books.FindIndex(val => val.Id == id);
        if (index != -1)
        {
            var updatedBook = new Book(book.Title, book.Genre, book.Author, book.Price, book.Quantity, id);
            Books[index] = updatedBook;
            return id;
        }
        return null;
    }
}
