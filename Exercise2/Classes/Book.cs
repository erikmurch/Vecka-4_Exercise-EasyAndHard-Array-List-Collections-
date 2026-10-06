public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public bool IsBorrowedOut { get; set; }

    public Book(string title, string author, int yearPublished, bool IsBorrowedOut)
    {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        this.IsBorrowedOut = IsBorrowedOut;

    }

    public void ShowInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year Published: {YearPublished} Is lended out: {IsBorrowedOut}");
    }
}