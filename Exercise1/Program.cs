Console.WriteLine("Ange hur många tal som ska lagras:");
int antalTal = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Ange talen:");
int[] tal = new int[antalTal];
int sum = 0;
for (int i = 0; i < antalTal; i++)
{
    tal[i] = Convert.ToInt32(Console.ReadLine());
    sum += tal[i];
}

Console.WriteLine($"Summan är {sum}");
Console.WriteLine($"Medelvärdet är {(double)sum / antalTal}");
