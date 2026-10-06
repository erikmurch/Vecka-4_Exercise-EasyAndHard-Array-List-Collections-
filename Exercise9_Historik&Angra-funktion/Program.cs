List <string> history = new List <string>();
// LIFO=Last in first out
Stack <string> undone = new Stack <string>();

bool keepRunning = true;

while (keepRunning)
{
    // \n skapar en radbrytning 
    Console.WriteLine("\n1. Lägg till text");
    Console.WriteLine("2. Ångra");
    Console.WriteLine("3. Gör om");
    Console.WriteLine("4. Visa historiken");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
        {
            Console.Write("Skriv text: ");
            string inputText = Console.ReadLine() ?? "";

            // Spara texten sist i historiklistan.
            history.Add(inputText);

            Console.WriteLine($"Tillagd: {inputText}");
            break;
        }

        case "2":
        {
            // Här ska jag ångra senaste textinmatningen.
            if(history.Count == 0)
                {
                    Console.WriteLine("Det finns inget att ångra");
                }
                // Räknar ut sista textens plats.
                // Index = Positionsnummer
                int lastIndex = history.Count - 1;

                //Hämtar texten på sista textens plats
                //[] betyder hämta värdet på denna platsen
                string lastText = history[lastIndex];

                // Sparar texten i stacken så att den kan göras om.
                // Push = Lägger till överst i en stack
                undone.Push(lastText);

                // Ta bort texten från historiken på dess index/positionsnummer.
                history.RemoveAt(lastIndex);

                Console.WriteLine($"Ångrade: {lastText}");
            break;
        }

        case "3":
        {
            // Här ska jag göra om en ångrad inmatning.
            if (undone.Count == 0)
            {
                Console.WriteLine("Det finns inget att göra om.");
                break;
            }
            // Hämtar och tar bort översta texten från stacken.
            //Pop = Hämtar och tar bort den översta
            string restoredText = undone.Pop();

            // Lägger tillbaka texten sist i historiklistan.
            history.Add(restoredText);

            Console.WriteLine($"Gjorde om: {restoredText}");
            break;
        }

        case "4":
        {
            // Här ska vi visa historiken.
            Console.WriteLine("Historik:");

            foreach (string currentText in history)
            {
                Console.WriteLine(currentText);
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