// En Dictionary lagrar nycklar och värden.
// Nyckeln är elevens namn (string).
// Värdet är elevens betyg (int).
// Anna och anna räknas som samma namn.
Dictionary<string, int> students =
    new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

// Programmet fortsätter så länge keepRunning är true.
bool keepRunning = true;

while (keepRunning)
{
    // Visa menyn varje gång loopen börjar om.
    Console.WriteLine("\n1. Lägg till elev och betyg");
    Console.WriteLine("2. Uppdatera betyg");
    Console.WriteLine("3. Visa alla elever och betyg");
    Console.WriteLine("4. Visa medelbetyget");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj ett alternativ: ");

    // Läs användarens val och försök göra om det till ett heltal.
    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Ange ett nummer.");

        // Börja om loopen och visa menyn igen.
        continue;
    }

    // Kör det alternativ som användaren valde.
    switch (choice)
    {
        case 1:
        {
            Console.Write("Ange elevens namn: ");

            // ?? "" ger en tom text om ReadLine inte ger något värde.
            // Trim tar bort mellanslag i början och slutet.
            string name = (Console.ReadLine() ?? "").Trim();

            // Kontrollera att namnet inte är tomt.
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Namnet får inte vara tomt.");
                break;
            }

            // Kontrollera om namnet redan finns i dictionaryn.
            if (students.ContainsKey(name))
            {
                Console.WriteLine("Eleven finns redan.");
                break;
            }

            Console.Write("Ange elevens betyg (heltal): ");

            // Kontrollera att betyget är ett heltal.
            if (!int.TryParse(Console.ReadLine(), out int grade))
            {
                Console.WriteLine("Betyget måste vara ett heltal.");
                break;
            }

            // Lägg till namnet som nyckel och betyget som värde.
            students.Add(name, grade);

            Console.WriteLine("Eleven och betyget har lagts till.");
            break;
        }

        case 2:
        {
            Console.Write("Ange namnet på eleven: ");
            string name = (Console.ReadLine() ?? "").Trim();

            // ! betyder "inte".
            // Om eleven inte finns kan vi inte uppdatera betyget.
            if (!students.ContainsKey(name))
            {
                Console.WriteLine("Eleven finns inte.");
                break;
            }

            Console.Write("Ange det nya betyget (heltal): ");

            if (!int.TryParse(Console.ReadLine(), out int newGrade))
            {
                Console.WriteLine("Betyget måste vara ett heltal.");
                break;
            }

            // Hitta eleven med namnet och ersätt det gamla betyget.
            students[name] = newGrade;

            Console.WriteLine("Betyget har uppdaterats.");
            break;
        }

        case 3:
        {
            // Count visar hur många elever som finns.
            if (students.Count == 0)
            {
                Console.WriteLine("Det finns inga elever.");
            }

            // Gå igenom varje nyckel–värde-par i dictionaryn.
            foreach (var elev in students)
            {
                // Key är namnet och Value är betyget.
                Console.WriteLine(
                    $"Elev: {elev.Key}, betyg: {elev.Value}");
            }

            break;
        }

        case 4:
        {
            // Det måste finnas betyg för att beräkna ett medelvärde.
            if (students.Count == 0)
            {
                Console.WriteLine("Det finns inga betyg att beräkna.");
                break;
            }

            // Values innehåller alla betyg.
            // Average räknar ut medelvärdet.
            // double används eftersom medelvärdet kan ha decimaler.
            double averageGrade = students.Values.Average();

            // F2 visar medelvärdet med två decimaler.
            Console.WriteLine($"Medelbetyget är: {averageGrade:F2}");
            break;
        }

        case 5:
            // false gör att while-loopen avslutas.
            keepRunning = false;
            Console.WriteLine("Programmet avslutas.");
            break;

        default:
            // Körs om användaren anger ett heltal som inte finns i menyn.
            Console.WriteLine("Välj ett alternativ mellan 1 och 5.");
            break;
    }

    // break i switch avslutar menyvalet.
    // Sedan börjar while-loopen om, om keepRunning fortfarande är true.
}