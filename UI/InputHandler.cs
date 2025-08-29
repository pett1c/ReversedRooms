using System;

namespace Reversedrooms.UI
{
    public class InputHandler
    {
        public ConsoleKey GetKey()
        {
            return Console.ReadKey(true).Key;
        }
    }
}