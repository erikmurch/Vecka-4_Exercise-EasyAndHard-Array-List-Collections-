List<Book> booklist = new List<Book>
{

};

void DisplayMenu()
{
    Menu menu = new Menu();
    menu.DisplayMenu();

    if( int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Add a book to the list:");
                Console.WriteLine("Enter the title of the book:");
                string title = Console.ReadLine();
                Console.WriteLine("Enter the author of the book:");
                string author = Console.ReadLine();
                Console.WriteLine("Enter the year of publication:");
                int year = int.Parse(Console.ReadLine());
                booklist.Add(new Book(title, author, year));
                break;
            case 2:
                foreach (Book book in booklist)
                {
                    book.ShowInfo();
                }
                break;
            case 3:
                Console.WriteLine("Enter the title of the book to search for:");
                string searchTitle = Console.ReadLine();
                Book? foundBook = booklist.Find(b => b.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));
                if (foundBook != null)
                {
                    foundBook.ShowInfo();
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
                break;

                case 4:
                Console.WriteLine("Exiting the application. Goodbye!");
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

    foreach (Book book in booklist)
{
    book.ShowInfo();
}

}

DisplayMenu();