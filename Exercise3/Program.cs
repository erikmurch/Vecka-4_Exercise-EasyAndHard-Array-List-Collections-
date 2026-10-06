// En Dictionary lagrar nycklar och värden.
// Nyckeln är elevens namn (string).
// Värdet är en lista med heltal.
// Anna och anna räknas som samma namn.
Dictionary<string, List<int>> students =
    new Dictionary<string, List<int>>(StringComparer.OrdinalIgnoreCase);

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

    // Läser användarens val och försöker göra om det till ett heltal.
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
            students.Add(name, new List<int> { grade });

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

            // students[name] hämtar elevens betyglista 
            // och .Add(newGrade) lägger till betyger utan att ta bort tidigare betyg.
            students[name].Add(newGrade);

            Console.WriteLine("Betyget har uppdaterats.");
            break;
        }

        case 3:
        {
            Console.Write("Ange elevens namn: ");
            string name = (Console.ReadLine() ?? "").Trim();

            // Om eleven inte finns avslutas menyvalet.
            if (!students.ContainsKey(name))
            {
                Console.WriteLine("Eleven finns inte.");
                break;
            }

            // Hämtar betygslistan för namnet användaren skrev.
            List<int> grades = students[name];

            // Beräknar listans genomsnitt.
            // double behövs eftersom svaret kan innehålla decimaler.
            double average = grades.Average();

            // Visar elevens namn och genomsnitt.
            Console.WriteLine($"Snittbetyget för {name} är {average}");

            break;
}

        case 4:
        {
            if (students.Count == 0)
            {
            Console.WriteLine("Det finns inga elever.");
            break;
            }

            foreach (var elev in students.OrderByDescending(elev => elev.Value.Average()))
            {
            // Beräknar genomsnittet för elevens betyg.
            double average = elev.Value.Average();

            // Visar elevens namn och genomsnitt.
            Console.WriteLine($"{elev.Key}: {average}");
            }

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