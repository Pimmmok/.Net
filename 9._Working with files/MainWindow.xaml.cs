using Microsoft.Win32;
using System.IO.Abstractions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace _9._Working_with_files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _fileName = string.Empty;
        private bool _richtextBoxChangedFlag = false;
        public IFileHandler FileHandler { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FileHandler = new FileHandler(new FileSystem());
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            TextRange document = new TextRange(richtextBox.Document.ContentStart, richtextBox.Document.ContentEnd);
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf"
            };
            if (saveFileDialog.ShowDialog() == true)
            {

                FileHandler.SaveToFile(saveFileDialog.FileName, document);
            }
            _richtextBoxChangedFlag = false;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (SavedText())
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    TextRange document = new TextRange(richtextBox.Document.ContentStart, richtextBox.Document.ContentEnd);
                    FileHandler.OpenToFile(openFileDialog.FileName, document);
                    _fileName = openFileDialog.FileName;
                }
            }
            _richtextBoxChangedFlag = false;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_fileName == string.Empty)
            {
                SaveAs_Click(this, null);
            }
            else
            {
                TextRange document = new TextRange(richtextBox.Document.ContentStart, richtextBox.Document.ContentEnd);
                FileHandler.SaveToFile(_fileName, document);
                _richtextBoxChangedFlag = false;
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (SavedText())
            {
                richtextBox.Document.Blocks.Clear();
                _fileName = string.Empty;
            }
            _richtextBoxChangedFlag = false;
        }

        private void RichtextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _richtextBoxChangedFlag = true;
        }

        private bool SavedText()

        {
            if (_richtextBoxChangedFlag)
            {
                switch (MessageBox.Show("Сохранить изменения в документе?", "Внимание", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        {
                            Save_Click(this, null);
                            return true;
                        }
                    case MessageBoxResult.Cancel:
                        {
                            return false;
                        }

                    default:
                        return true;
                }
            }
            return true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !SavedText();
        }
    }
}