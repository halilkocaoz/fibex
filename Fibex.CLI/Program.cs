using System;

namespace Fibex.CLI
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool outputSelected;
            if (args.Length == 0)
            {
                Default();
            }
            else if (args[0] == "do")
            {
                if (args.Length > 1)
                {
                    outputSelected = args.Length > 2 && (args[2] == "-o" || args[2] == "--output");
                    Commands.Do(args[1], outputSelected);
                }
                else
                {
                    Warn("You should pass the target directory after the 'do' command");
                    Info("do {targetDirectory}\ndo {targetDirectory} -o || --output");
                }
            }
            else if (args[0] == "undo")
            {
                if (args.Length > 1)
                {
                    Commands.Undo(args[1]);
                }
                else
                {
                    Warn("You should pass the target directory after the 'undo' command");
                    Info("undo {targetDirectory}");
                }
            }
            else
            {
                Warn(args[0] + " is unknown command");
                Default();
            }
        }
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public static void Default()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("do command: Process the directory and Group the files which are in directory\n    " +
            "It needs a target directory to process files and after then to group them.\n    " +
            "do {targetDirectory}\n    do {targetDirectory} -o || --output\n");
            Console.WriteLine("undo command: Revert the directory\n    " +
            "It needs a target directory to revert \n    " +
            "undo {targetDirectory}");
            Console.ResetColor();
        }
    }
}
