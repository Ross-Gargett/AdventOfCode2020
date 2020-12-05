using System;

namespace AdventOfCode.Classes.Services
{
    public class AdventOfCodeProgram
    {
        public static void OutputWelcomeMessage(int dayNum)
        {
            Console.WriteLine(String.Format(Constants.WelcomeMessage, dayNum));
        }

        public static void OutputGoodbyeMessage()
        {
            Console.WriteLine(String.Format(Constants.GoodbyeMessage));
            Console.ReadLine();
        }
    }
}
