using System;

namespace Fibex.CLI
{
    class Program
    {
        private static readonly FileManager _fileManager = new FileManager();

        static void Main(string[] args)
        {
            bool outputSelected;
            if (args.Length == 0)
            {
                //todo default information
            }
            else if (args[0] == "do")
            {
                if (args.Length > 1)
                {
                    outputSelected = args.Length > 2 && (args[2] == "-o" || args[2] == "--output");
                    _fileManager.Process(args[1], outputSelected);
                }
                else
                {
                    // todo warn
                }
            }
            else if (args[0] == "undo")
            {
                //todo: undo
            }
            else if (args[0] == "--help" || args[0] == "-h")
            {
                //todo default information
            }
            else
            {
                // todo warn
            }
        }
    }
}
