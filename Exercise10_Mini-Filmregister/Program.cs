using System.Collections.Immutable;

List<Film> films = new List<Film>();

bool keepRunning = true;

while (keepRunning)

{
    Console.WriteLine("\n1) Lägg till film:");
    Console.WriteLine("2) Sök efter genre:");
    Console.WriteLine("3) Visa top 3 filmer:");
    Console.WriteLine("4) Ta bort film:");
    Console.WriteLine("5) Avsluta:");
    Console.Write("Välj:");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
        {
            Console.Write("Ange filmens titel: ");
            string enteredTitel = Console.ReadLine() ?? "";

            Console.Write("Ange filmens genre: ");
            string enteredGenre = Console.ReadLine() ?? "";

            Console.Write("Ange betyg 1 till 10: ");
            if (!int.TryParse(Console.ReadLine(), out int enteredRating))
            {
                Console.WriteLine("Betyget måste vara ett heltal.");
                break;
            }

            // Betyget ska vara mellan 1 och 10 enligt instruktionerna.
            if (enteredRating < 1 || enteredRating > 10)
            {
                Console.WriteLine("Betyget måste vara mellan 1 och 10.");
                break;
            }

            // Skapar filmobjektet med de tre inmatade värdena.
            Film newFilm = new Film(enteredTitel, enteredGenre, enteredRating);

            // Lägger objektet i listan.
            films.Add(newFilm);

Console.WriteLine($"Filmen '{newFilm.Titel}' har lagts till.");

            break;
        }

        case "2":
        {
            // Sök efter genre.
            Console.Write("Vilken genre vill du söka efter? ");
            string searchedGenre = Console.ReadLine() ?? "";

            foreach (Film currentFilm in films)
                {
                    // Jämför filmens genre med användrens sökning
                    if ( currentFilm.Genre == searchedGenre)
                    {
                        Console.WriteLine($"{currentFilm.Titel} - betyg {currentFilm.Rating}");
                        
                    }
                }
            break;
        }

        case "3":
        {
            // Visa topp 3.
            foreach (Film currentFilm in films.OrderByDescending(film => film.Rating)
            .Take(3))
                {
                    Console.WriteLine($"{currentFilm.Titel} - betyg {currentFilm.Rating}");
                    
                }
                
            break;
        }

        case "4":
        {
            // Ta bort film.
            Console.Write("Ange titeln på filmen du vill ta bort: ");
            string searchedTitel = Console.ReadLine() ?? "";

            // Find söker efter första filmen där det stämmer
            //Om inget matchar blir resultatet null/inget
            Film? filmToRemove = films.Find(currentFilm => currentFilm.Titel == searchedTitel);

            if (filmToRemove == null)
                {
                    Console.WriteLine("Filmen hittades inte.");
                }
                else
                {
                    films.Remove(filmToRemove);
                    Console.WriteLine($"Filmen {filmToRemove.Titel} har tagits bort.");
                }
            break;
        }

        case "5":
        {
            keepRunning = false;
            break;
        }

        default:
            Console.WriteLine("Välj ett alternativ mellan 1 och 5.");
            break;
    }
}