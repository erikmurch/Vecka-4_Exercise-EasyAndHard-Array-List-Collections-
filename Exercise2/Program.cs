internal class Program
{

    Book book1 = new Book("Harry Potter", "J.K. Rowling", 1997, false);
    private static void Main(string[] args)
    {
        Biblbotek biblotek = new Biblbotek();
        
        bool keepRunning = true;

        void DisplayMenu()
        {
            Menu menu = new Menu();
            menu.DisplayMenu();

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add a book to the list:");
                        Console.WriteLine("Enter the title of the book:");
                        string title = Console.ReadLine()!;
                        Console.WriteLine("Enter the author of the book:");
                        string author = Console.ReadLine()!;
                        Console.WriteLine("Enter the year of publication:");
                        int year = int.Parse(Console.ReadLine()!);
                        Book book = new Book(title, author, year, false); //Skapar bokobjektet användaren skrev in
                        biblotek.AddBook(book); // anropar bibliotek metod och skickar med bokobjektet. I Bibliotek-klass tar book emot objektet, och booklist.Add(book) lägger det i listan.
                        break;
                    case 2:
                        biblotek.ShowAllBooks();

                        Console.WriteLine("Skriv titeln på boken du vill låna:");
                        string searchedTitle = Console.ReadLine()!;

                        biblotek.BorrowBook(searchedTitle);
                        break;

                    case 3:
                        Console.WriteLine("Skriv in titeln på boken du lämnar tillbaka.");
                        string returnTitle = Console.ReadLine()!;
                        biblotek.ReturnBook(returnTitle);
                        break;

                    case 4:
                        Console.WriteLine("Enter name or author of the book youre looking for:");
                        string searchText = Console.ReadLine()!;
                        biblotek.SearchBooks(searchText);
                        break;

                    case 5:
                        biblotek.ShowAvailableBooks();
                        break;
                        


                    case 6:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

        while (keepRunning)
{
    DisplayMenu();
}
    }
}