using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.IO.Abstractions;

namespace _9._Working_with_files
{
    public class FileHandler : IFileHandler
    {
        private readonly IFileSystem _fileSystem;
        public FileHandler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void OpenToFile(string fileName, TextRange document)
        {
            try
            {
                using Stream stream = _fileSystem.FileStream.Create(fileName, FileMode.Open);
                if (Path.GetExtension(fileName).ToLower() == ".rtf")
                {
                    document.Load(stream, DataFormats.Rtf);
                }
                else if (Path.GetExtension(fileName).ToLower() == ".txt")
                {
                    document.Load(stream, DataFormats.Text);
                }
            }
            catch (IOException ex)
            {
                ex.Data.Add("Filename", fileName);
                ex.Data.Add("Operation", "Open");
                throw;
            }
        }

        public void SaveToFile(string fileName, TextRange document)
        {
            try
            {
                using Stream stream = _fileSystem.FileStream.Create(fileName, FileMode.OpenOrCreate);
                if (Path.GetExtension(fileName).ToLower() == ".rtf")
                {
                    document.Save(stream, DataFormats.Rtf);

                }
                else if (Path.GetExtension(fileName).ToLower() == ".txt")
                {
                    document.Save(stream, DataFormats.Text);
                }
            }
            catch (IOException ex)
            {
                ex.Data.Add("Filename", fileName);
                ex.Data.Add("Operation", "Save");
                throw;
            }
        }
    }
}

