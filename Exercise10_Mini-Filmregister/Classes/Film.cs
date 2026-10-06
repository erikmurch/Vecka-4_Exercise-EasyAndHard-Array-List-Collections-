public class Film
{
    public string Titel { get; set; }
    public string Genre { get; set; }
    public int Rating { get; set; }

//string enteredGenre deklarerar parametern,
// medan Genre = enteredGenre; sparar dess värde i egenskapen.
    public Film(string enteredTitel, string enteredGenre, int enteredRating)
    {
        Titel = enteredTitel;
        Genre = enteredGenre;
        Rating = enteredRating;
    }
}