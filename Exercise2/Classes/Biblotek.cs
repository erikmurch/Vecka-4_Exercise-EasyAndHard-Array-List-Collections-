public class Biblbotek
{
    List<Book> bookList = new List<Book>
    {
        
    };



public void AddBook(Book book)// Tar emot objektet
    {
        bookList.Add(book); // Lägger till det i listan
    }

public void ShowAllBooks()
    {
        foreach (Book book in bookList)
        {
            book.ShowInfo();
        }
    }

public void BorrowBook(string title)
{
    foreach (Book currentBook in bookList)
    {
        // kontrollerar vi om titeln matchar.
        if (currentBook.Title == title)
        {
            // kontrollerar  om den redan är utlånad.
            if (currentBook.IsBorrowedOut == true)
            {
                Console.WriteLine("Boken är redan utlånad.");
            }
            else
            {
                // Boken är ledig, så vi markerar den som utlånad.
                currentBook.IsBorrowedOut = true;
                Console.WriteLine($"Du lånar '{currentBook.Title}'.");
            }

            return;
        }
    }

    // kommer hit bara om ingen titel matchade.
    Console.WriteLine("Boken hittades inte.");
}

public void ReturnBook(string title)
{
    foreach (Book currentBook in bookList)
    {
        if (currentBook.Title == title)
        {
            if (currentBook.IsBorrowedOut == false)
            {
                Console.WriteLine("Boken är inte utlånad.");
            }
            else
            {
                currentBook.IsBorrowedOut = false;
                Console.WriteLine("Boken har lämnats tillbaka.");
            }

            return;
        }
    }

    // kommer hit bara om ingen titel matchade.
    Console.WriteLine("Boken hittades inte.");
}

public void SearchBooks (string searchText)
    {
        foreach (Book currentBook in bookList)
        {
            if (currentBook.Title.Contains(searchText) ||
            currentBook.Author.Contains(searchText))
            {
                currentBook.ShowInfo();
            }
        }
    }

public void ShowAvailableBooks()
    {
        foreach (Book currentBook in bookList)
        {
            if (currentBook.IsBorrowedOut == false)
            {
                currentBook.ShowInfo();
            }
        }
    }

}
