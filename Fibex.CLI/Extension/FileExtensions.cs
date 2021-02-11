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
            {
                Program.Warn(file.Name + " could not move.");
            }
        }

    }
}