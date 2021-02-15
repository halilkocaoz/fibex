using System.IO;
using Fibex.CLI.Model;

namespace Fibex.CLI.Extension
{
    public static class FileExtensions
    {
        private static void CreateDirectoryByFile(FileModel file)
        {
            if (!Directory.Exists(file.DestDirectory))
            {
                Directory.CreateDirectory(file.DestDirectory);
            }
        }
        public static void Move(this FileModel file)
        {
            CreateDirectoryByFile(file);
            if (!File.Exists(file.DestPath))
            {
                File.Move(file.CurrentPath, file.DestPath);
                Program.Info(file.Name + " moved.");
            }
            else
                Program.Warn(file.Name + " could not move, because there is file with same name.");
        }
        public static void Revert(this FileModel file)
        {
            var currentPathName = Directory.GetParent(file.CurrentPath).Name;
            var currentPathFullDirectory = Directory.GetParent(file.CurrentPath).FullName;

            var previousPath = !file.CurrentPath.Contains("output")
            ? Directory.GetParent(file.CurrentPath).Parent.FullName
            : Directory.GetParent(file.CurrentPath).Parent.Parent.FullName;

            var pathToRevert = previousPath + "/" + file.Name;

            if (currentPathName == file.Extension)
            {
                if (!File.Exists(pathToRevert))
                {
                    File.Move(file.CurrentPath, pathToRevert);
                    Program.Info(file.Name + " was reverted.");
                }
                else
                    Program.Warn(file.Name + " could not revert, because there is file with same name.");
            }

            var currentPathFiles = Directory.GetFiles(currentPathFullDirectory);
            if (currentPathFiles.Length == 0)
                Directory.Delete(currentPathFullDirectory);
        }
    }
}