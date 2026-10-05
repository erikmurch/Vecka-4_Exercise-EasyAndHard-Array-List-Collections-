public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }

    public Book(string title, string author, int yearPublished)
    {
        Title = title;
        Author = author;
        YearPublished = yearPublished;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year Published: {YearPublished}");
    }
}