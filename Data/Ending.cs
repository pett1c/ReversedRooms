namespace Reversedrooms.Data
{
    public static class Ending
    {
        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("The lift doors close with a loud creak. You feel a jolt as it begins to move.");
            Console.WriteLine("The buzzing lights flicker, and the air grows colder.");
            Console.WriteLine("After what feels like an eternity, the lift stops, and the doors open.");
            Console.WriteLine("You step out into blinding light, unsure if you've escaped... or entered something worse.");
            Console.WriteLine();
            Console.WriteLine("> The End <");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}