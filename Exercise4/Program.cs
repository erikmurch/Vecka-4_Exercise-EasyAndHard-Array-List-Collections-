// tasks är namnet på vår variabel.
// new Queue<string>() skapar en ny, tom kö.
// FIFO = First In, First Out.
// Den uppgift som läggs till först tas också bort först.
List<Task> tasks = new List<Task>();

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
    case "1":
{
    Console.Write("Skriv uppgiften: ");
    string task = Console.ReadLine() ?? "";

    // Kontrollerar titeln innan uppgiften sparas.
    if (string.IsNullOrWhiteSpace(task))
    {
        Console.WriteLine("Uppgiften får inte vara tom.");
        break;
    }

    // Visa frågan INNAN vi läser användarens svar.
    Console.WriteLine("Ange prioritet: 1 = hög, 2 = medel, 3 = låg:");

    // Läser svaret och försöker omvandla det till ett heltal.
    if (!int.TryParse(Console.ReadLine(), out int enteringPriority))
    {
        Console.WriteLine("Prioriteten måste vara ett heltal.");
        break;
    }

    // Skapar objektet med titeln och prioriteten.
    Task task1 = new Task(task, enteringPriority);

    // Sparar objektet i listan.
    tasks.Add(task1);

    // Bekräfta att uppgiften sparats.
    Console.WriteLine(
        $"Uppgiften '{task1.Title}' har lagts till med prioriteten {task1.Priority}");

    break;
}


case "2":
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Det finns inga uppgifter.");
        break;
    }

    // Sortera prioritet och hämta första uppgiften.
    Task nextTask = tasks
        .OrderBy(currentTask => currentTask.Priority)
        .First();

    Console.WriteLine($"Nästa uppgift: {nextTask.Title}");

    break;
}
case "3":
{
    // Kontrollera att listan innehåller någon uppgift.
    if (tasks.Count == 0)
    {
        Console.WriteLine("Det finns ingen uppgift att slutföra.");
        break;
    }

    // Hitta uppgiften med lägst tal, alltså högst prioritet.
    Task completedTask = tasks
        .OrderBy(item => item.Priority)
        .First();

    // Ta bort den valda uppgiften från listan.
    tasks.Remove(completedTask);

    // Visa titeln på uppgiften som slutfördes.
    Console.WriteLine($"Slutförd: {completedTask.Title}");

    break;
}

case "4":
{
    foreach (Task currentTask in tasks.OrderBy(item => item.Priority))
    {
        Console.WriteLine(
            $"{currentTask.Title} – prioritet {currentTask.Priority}");
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