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
        public static void Do(this FileModel file)
        {
            CreateDirectoryByFile(file);
            if (!File.Exists(file.DestPath))
            {
                File.Move(file.CurrentPath, file.DestPath);
                Program.Info(file.Name + " moved.");
            }
            else
            {
                Program.Warn(file.Name + " could not move.");
            }
        }
        public static void Undo(this FileModel file)
        {
            var currentPathName = Directory.GetParent(file.CurrentPath).Name;
            var currentPathFullDirectory = Directory.GetParent(file.CurrentPath).FullName;

            var previousPath = !file.CurrentPath.Contains("output")
            ? Directory.GetParent(file.CurrentPath).Parent.FullName
            : Directory.GetParent(file.CurrentPath).Parent.Parent.FullName;

            if (currentPathName == file.Extension)
                File.Move(file.CurrentPath, previousPath + "/" + file.Name);

            var currentPathFiles = Directory.GetFiles(currentPathFullDirectory);
            if (currentPathFiles.Length == 0)
                Directory.Delete(currentPathFullDirectory);
        }
    }
}