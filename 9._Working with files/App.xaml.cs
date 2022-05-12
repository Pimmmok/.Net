using System.IO;
using System.Windows;

namespace _9._Working_with_files
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is IOException)
            {
                if (e.Exception.Data["Operation"].Equals("Open"))
                {
                    _ = MessageBox.Show(e.Exception.Message + "\nПроизошло исключение при открытии файла:"
                    + e.Exception.Data["Filename"].ToString(), "Ошибка");
                }
                else
                {
                    _ = MessageBox.Show(e.Exception.Message + "\nПроизошло исключение при сохранении файла :"
                    + e.Exception.Data["Filename"].ToString(), "Ошибка");
                }
                e.Handled = true;
            }
            else
            {
                _ = MessageBox.Show("Произошло необработанное исключение: "
                + e.Exception.Message, "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
            }
        }
    }
}
