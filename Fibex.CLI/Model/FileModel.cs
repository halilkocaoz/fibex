using System;
using System.IO;

namespace Fibex.CLI.Model
{
    public class FileModel : IDisposable
    {
        public FileModel(string filePath, string targetDirectory, bool output)
        {
            if (File.Exists(filePath))
            {
                Name = Path.GetFileName(filePath);
                Extension = Path.GetExtension(filePath).Replace(".", "");
                CurrentPath = filePath;
                DestDirectory = output ? targetDirectory + "/output/" + Extension + "/" : targetDirectory + "/" + Extension + "/";
            }
        }
        public string CurrentPath { get; set; }
        public string DestDirectory { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}