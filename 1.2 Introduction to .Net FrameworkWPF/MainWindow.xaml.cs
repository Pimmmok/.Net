using Introduction_to_.Net_Framework;
using System.Windows;
namespace Introduction_to_.Net_FrameworkWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// WPF-application entry point.
        /// </summary>
        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }
        private void ButtonFormatFromTextBoxToTextBox_Click(object sender, RoutedEventArgs e)
        {
            Context<Coordinate> context = new Context<Coordinate>(
                new TextBoxCoordinateReader(ReadTextBox), new TextBoxCoordinateWriter(WriteTextBox));
            context.ExecuteDataProcessing();
        }

        private void ButtonFormatFromFileToTextBox_Click(object sender, RoutedEventArgs e)
        {
            Context<Coordinate> context = new Context<Coordinate>(new FileCoordinateWPFReaderWpfProgram(),
                                                                  new TextBoxCoordinateWriter(WriteTextBox));
            context.ExecuteDataProcessing();
        }

        private void ButtonFormatFromTextBoxToFile_Click(object sender, RoutedEventArgs e)
        {
            Context<Coordinate> context = new Context<Coordinate>(new TextBoxCoordinateReader(ReadTextBox),
                                                                  new FileCoordinateWriterWpfProgram());
            context.ExecuteDataProcessing();
        }

        private void ButtonFormatFromFileToFile_Click(object sender, RoutedEventArgs e)
        {
            Context<Coordinate> context = new Context<Coordinate>(
                new FileCoordinateWPFReaderWpfProgram(), new FileCoordinateWriterWpfProgram());
            context.ExecuteDataProcessing();
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            ReadTextBox.Text = "14,5\n17.77,88.334891\n11.41925,78.1781981";
            Context<Coordinate> context = new Context<Coordinate>(
                new TextBoxCoordinateReader(ReadTextBox), new TextBoxCoordinateWriter(WriteTextBox));
            context.ExecuteDataProcessing();
        }
    }
}
