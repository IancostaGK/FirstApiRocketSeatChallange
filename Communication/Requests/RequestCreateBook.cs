namespace FirstApi.Communication.Requests;

public class RequestCreateBook(string title, string genre, string author, float price, int quantity)
{
    public string Title { get; set; } = title;
    public string Genre { get; set; } = genre;
    public string Author { get; set; } = author;
    public float Price { get; set; } = price;
    public int Quantity { get; set; } = quantity;
}

