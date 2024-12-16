namespace FirstApi.Entities;

public class Book
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    public Book(string title, string genre, string author, float price, int quantity, long? id = null)
    {
        Id = id ?? new Random().NextInt64(1, long.MaxValue);
        Title = title;
        Genre = genre;
        Author = author;
        Price = price;
        Quantity = quantity;
    }
}
