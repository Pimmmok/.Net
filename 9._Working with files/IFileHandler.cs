using System.Windows.Documents;

namespace _9._Working_with_files
{
    public interface IFileHandler
    {
        public void OpenToFile(string fileName, TextRange document);

        public void SaveToFile(string fileName, TextRange document);
    }
}
