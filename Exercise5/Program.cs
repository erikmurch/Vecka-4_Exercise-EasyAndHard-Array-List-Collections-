using System;
using System.Collections.Generic;
// Gör en stack som lagrar textinmatningar.
Stack<string> textStack = new Stack<string>();
// Säger att loopen ska fortsätta till användaren väljer att avsluta.
bool keepRunning = true;

while (keepRunning)
{
    // Skriver ut menyn.
    Console.WriteLine("1) Lägg till text (Push)");
    Console.WriteLine("2) Ångra senaste inmatningen (Pop)");
    Console.WriteLine("3) Visa aktuell text");
    Console.WriteLine("4) Avsluta");
    Console.Write("Välj: ");
    
    // Läser in användares val och hanterar null/inget värde med ??, ?? betyder använd värdet
    // till höger om värdet till vänster är null/inget.
    string choice = Console.ReadLine() ?? "";

    // Switch kontrollerar användarens val och kör motsvarande case.
    switch (choice)
    {
        // Om case 1 så köra detta kodblock.
        case "1":
            Console.Write("Skriv texten du vill lägga till: "); // Först frågas användaren om texten den vill ska läggas till i stacken.
            string inputText = Console.ReadLine() ?? "";        // Läser in texten med variabeln inputText och hanterar null/inget värde med ??.
            textStack.Push(inputText);                          // textStack.Push lägger till texten och döpte push variablen till textStack.
                                                                // inputText Den tar in texten som skrivits och lägger till den i stacken.
            Console.WriteLine($"Texten {inputText} har lagts till i stacken."); // Skriver ut texten som lagts till.
            break; // Avslutar case 1 och sen ska den köra vidare loopen, alltså kommer den tillbaka till menyn.

        case "2":
            if (textStack.Count > 0) // Om stacken (text.Stack.Count) har fler än 0 textinmatningar så körs detta kodblock
            //  om inte så körs else kodblocket.
            {
                string removedText = textStack.Pop(); // textStack.Pop tar bort texten som lades till senast och sparar den i variablen removedText.
                Console.WriteLine($"Texten {removedText} har tagits bort från stacken."); // Skriver ut texten som tagits bort.
            }
            else
            {
                Console.WriteLine("Stacken är tom, inget att ångra.");
            }
            break;

        case "3":
            if (textStack.Count > 0) // Om stacken har fler än 0 textinmatningar så körs detta kodblock.
            {
                Console.WriteLine("Aktuell text i stacken:");
                foreach (string text in textStack) // foreach går igenom varje textinmatning som finns i stacken och sparar den i variablen text.
                {
                    Console.WriteLine($"- {text}");
                }
            }
            else
            {
                Console.WriteLine("Stacken är tom.");
            }
            break;

        case "4":
            keepRunning = false; // Sätter keepRunning till false så att while-loppen avslutas.
            Console.WriteLine("Programmet avslutas.");
            break;

        default: // Om använaren väljer ett altvernativ som inte finns så körs detta kodblock.
            Console.WriteLine("Ogiltligt val, försök igen.");
            break;
    }

    Console.WriteLine(); // Skirver ut en tom rad för att separera menyn från nästa kommande meny.
}