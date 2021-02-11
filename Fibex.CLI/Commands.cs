using System.IO;
using Fibex.CLI.Extension;
using Fibex.CLI.Model;
namespace Fibex.CLI
{
    public static class Commands
    {
        public static void Do(string targetDirectory, bool output)
        {
            if (Directory.Exists(targetDirectory))
            {
                var filePaths = Directory.GetFiles(targetDirectory);
                if (filePaths.Length != 0)
                {
                    foreach (var filePath in filePaths)
                    {
                        FileModel file = new FileModel(filePath, targetDirectory, output);
                        file.Move();
                    }
                }
                else
                    Program.Info("There is no file to group : " + targetDirectory);
            }
            else
                Program.Warn(targetDirectory + " is not found.");
        }
        public static void Undo(string targetDirectory)
        {
            Program.Warn("undo command is not useable now.");
        }
    }
}