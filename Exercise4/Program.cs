// tasks är namnet på vår variabel.
// new Queue<string>() skapar en ny, tom kö.
// FIFO = First In, First Out.
// Den uppgift som läggs till först tas också bort först.
Queue<string> tasks = new Queue<string>();

// bool är en datatyp som kan vara true eller false.
// Variabeln bestämmer om programmet ska fortsätta köras.
bool keepRunning = true;

// while upprepar koden mellan klamrarna så länge villkoret är true.
while (keepRunning)
{
    // WriteLine skriver text och går sedan till nästa rad.
    // \n skapar en radbrytning före menyn.
    Console.WriteLine("\n1. Lägg till en uppgift");
    Console.WriteLine("2. Visa nästa uppgift");
    Console.WriteLine("3. Slutför nästa uppgift");
    Console.WriteLine("4. Visa alla återstående uppgifter");
    Console.WriteLine("5. Avsluta");

    // Write skriver text utan att gå till nästa rad.
    Console.Write("Välj: ");

    // Svaret är text, även om användaren skriver en siffra.
    // ?? betyder: använd värdet till höger om värdet till vänster är null.
    // "" är en tom text.
    // choice är namnet på variabeln som sparar valet.
    string choice = Console.ReadLine() ?? "";

    // switch kontrollerar värdet i choice.
    // Det case som matchar användarens val körs.
    switch (choice)
    {
        // "1" har citationstecken eftersom choice är en string.
        case "1":
        {
            Console.Write("Skriv uppgiften: ");

            
            string task = (Console.ReadLine() ?? "");

            // if kör sin kod om villkoret är true.
            // IsNullOrWhiteSpace kontrollerar om texten saknas,
            // är tom eller bara innehåller blanksteg.
            if (string.IsNullOrWhiteSpace(task))
            {
                Console.WriteLine("Uppgiften får inte vara tom.");

                // break avslutar detta switch-val.
                // Programmet fortsätter sedan till slutet av while-loopen.
                break;
            }

            // Enqueue lägger till uppgiften sist i kön.
            // Befintliga uppgifter ligger fortfarande före den.
            tasks.Enqueue(task);

            // $ gör att vi kan lägga in variabler i texten med { }.
            Console.WriteLine($"Tillagd: {task}");
            break;
        }

        case "2":
        {
            // Count anger hur många uppgifter som finns i kön.
            // == jämför två värden.
            // Count == 0 betyder alltså att kön är tom.
            if (tasks.Count == 0)
            {
                Console.WriteLine("Kön är tom.");
                break;
            }

            // Peek returnerar den första uppgiften.
            // Returnerar betyder att metoden ger tillbaka ett värde.
            // Värdet sparas i variabeln nextTask.
            // Uppgiften tas INTE bort från kön.
            string nextTask = tasks.Peek();

            Console.WriteLine($"Nästa uppgift: {nextTask}");
            break;
        }

        case "3":
        {
            // Vi kontrollerar först att det finns något att ta bort.
            // Dequeue på en tom kö skulle orsaka ett körningsfel.
            if (tasks.Count == 0)
            {
                Console.WriteLine("Det finns ingen uppgift att slutföra.");
                break;
            }

            // Dequeue gör två saker:
            // 1. Tar bort den första uppgiften från kön.
            // 2. Returnerar uppgiften som togs bort.
            // Vi sparar den borttagna uppgiften för att kunna visa den.
            string completedTask = tasks.Dequeue();

            Console.WriteLine($"Slutförd: {completedTask}");
            break;
        }

        case "4":
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Det finns inga uppgifter kvar.");
                break;
            }

            Console.WriteLine("Återstående uppgifter:");

            // foreach går igenom varje uppgift i kön.
            // Vid varje varv innehåller task nästa uppgift.
            // Uppgifterna visas från först till sist.
            // foreach tar inte bort något från kön.
            foreach (string task in tasks)
            {
                Console.WriteLine($"- {task}");
            }

            break;
        }

        case "5":
            // = tilldelar ett värde till en variabel.
            // Här ändras keepRunning från true till false.
            keepRunning = false;

            // break avslutar switch.
            // När while sedan kontrollerar keepRunning är värdet false,
            // så loopen avslutas.
            break;

        // default körs om inget case matchar.
        default:
            Console.WriteLine("Välj ett alternativ mellan 1 och 5.");
            break;
    }

    // Här slutar ett varv av while-loopen.
    // Om keepRunning är true börjar nästa varv och menyn visas igen.
}