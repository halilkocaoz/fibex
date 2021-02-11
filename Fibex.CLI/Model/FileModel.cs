using System;
using System.IO;

namespace Fibex.CLI.Model
{
    public class FileModel : IDisposable
    {
        public FileModel(string filePath, bool output, string targetDirectory = null)
        {
            if (File.Exists(filePath))
            {
                Name = Path.GetFileName(filePath);
                Extension = Path.GetExtension(filePath).Replace(".", "");
                CurrentPath = filePath;
                if (!string.IsNullOrEmpty(targetDirectory))
                {
                    DestDirectory = output ? targetDirectory + "/output/" + Extension + "/" : targetDirectory + "/" + Extension + "/";
                    DestPath = DestDirectory + Name;
                }
            }
        }
        public string CurrentPath { get; set; }
        public string DestPath { get; set; }
        public string DestDirectory { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}