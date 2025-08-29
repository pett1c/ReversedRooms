namespace Reversedrooms.Data
{
    public static class Prologue
    {
        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("2042. The world is in chaos: pandemics, ecological disasters, and geopolitical conflicts have led to a global crisis.");
            Console.WriteLine("One state has seized total control over the planet, creating a harshly controlled system.");
            Console.WriteLine("You are a hired assassin working for a company that 'eliminates certain individuals.'");
            Console.WriteLine("On one of your rare days off, you encounter a strange, flickering coffee machine.");
            Console.WriteLine("Deciding to buy a coffee, you discover the machine is a neural network offering 'new drinks.'");
            Console.WriteLine("After drinking, you lose consciousness and wake up in strange yellow corridors...");
            Console.WriteLine();
            Console.WriteLine("> Continue <");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}