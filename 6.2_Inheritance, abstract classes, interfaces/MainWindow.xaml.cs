using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace _6._2_3_Inheritance__abstract_classes__interfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBoxReadData.Text = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                using FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                LoadingBarStream streamLoadingBar = new LoadingBarStream(fileStream);
                PasswordStream streamPassword = new PasswordStream(streamLoadingBar);
                byte[] buffer = new byte[streamPassword.Length];
                _ = streamPassword.Read(buffer, 0, (int)streamPassword.Length);
                textBoxReadData.Text = Encoding.UTF8.GetString(buffer);
            }
        }
    }
}

