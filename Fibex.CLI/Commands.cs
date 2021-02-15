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
                    foreach (var filePath in filePaths)
                        new FileModel(filePath, output, targetDirectory).Move();
                else
                    Program.Info("There is no file to group : " + targetDirectory);
            }
            else
                Program.Warn(targetDirectory + " is not found.");
        }
        public static void Undo(string targetDirectory)
        {
            if (Directory.Exists(targetDirectory))
            {
                var directories = Directory.GetDirectories(targetDirectory);
                var isInOutput = directories.Length > 0 && directories[0].Contains("output");
                if (isInOutput)
                {
                    targetDirectory = targetDirectory + "/output/";
                    directories = Directory.GetDirectories(targetDirectory);
                }

                if (directories.Length > 0)
                {
                    foreach (var directory in directories)
                    {
                        var directoryFiles = Directory.GetFiles(directory);
                        foreach (var filePath in directoryFiles)
                            new FileModel(filePath, false).Revert();
                    }

                    if (isInOutput && Directory.GetDirectories(targetDirectory).Length == 0)
                        Directory.Delete(targetDirectory);
                }
                else
                    Program.Warn("There is nothing to revert");
            }
            else
                Program.Warn(targetDirectory + " is not found.");
        }
    }
}