using System.IO;
using Fibex.CLI.Model;
namespace Fibex.CLI
{
    public class FileManager
    {
        //todo: seperate if it needs and find a clear name
        public void Process(string targetDirectory, bool output)
        {
            if (Directory.Exists(targetDirectory))
            {
                var filePaths = Directory.GetFiles(targetDirectory);
                foreach (var filePath in filePaths)
                {
                    var file = new FileModel(filePath, targetDirectory, output);
                    if (!Directory.Exists(file.DestDirectory)) Directory.CreateDirectory(file.DestDirectory);
                    if (!File.Exists(file.DestDirectory + file.Name)) File.Move(file.CurrentPath, file.DestDirectory + file.Name);
                }
            }
            else
            {
                //todo: directory not found
            }
        }
    }
}