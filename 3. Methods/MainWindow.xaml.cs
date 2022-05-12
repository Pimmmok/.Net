using System;
using System.Windows;
using System.Windows.Media;

namespace _3._Methods
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            checkBoxTwo.IsChecked = true;
        }

        private void CheckBoxTwo_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxThree.IsChecked = false;
            checkBoxFive.IsChecked = false;
            checkBoxFour.IsChecked = false;
        }

        private void CheckBoxThree_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxTwo.IsChecked = false;
            checkBoxFive.IsChecked = false;
            checkBoxFour.IsChecked = false;
        }

        private void CheckBoxFour_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxThree.IsChecked = false;
            checkBoxFive.IsChecked = false;
            checkBoxTwo.IsChecked = false;
        }

        private void CheckBoxFive_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxThree.IsChecked = false;
            checkBoxTwo.IsChecked = false;
            checkBoxFour.IsChecked = false;
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            textBoxNumberOne.Clear();
            textBoxNumberTwo.Clear();
            textBoxNumberThree.Clear();
            textBoxNumberFour.Clear();
            textBoxNumberFive.Clear();
            textBoxResult.Clear();
            diagramGrid.Children.Clear();
        }

        private void ButtonEuclidCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxTwo.IsChecked ?? false)
            {
                if (int.TryParse(textBoxNumberOne.Text, out int numberOne) & int.TryParse(textBoxNumberTwo.Text, out int numberTwo))
                {
                    textBoxResult.Text = new string("НОД: "
                                                    + CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, out TimeSpan time).ToString()
                                                    + " время выполнения: "
                                                    + time.TotalMilliseconds.ToString());
                }
                else
                {
                    _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
                }
            }
            if (checkBoxThree.IsChecked ?? false)
            {
                if (int.TryParse(textBoxNumberOne.Text, out int numberOne)
                    & int.TryParse(textBoxNumberTwo.Text, out int numberTwo)
                    & int.TryParse(textBoxNumberThree.Text, out int numberThree))
                {
                    textBoxResult.Text = CalculatorNod.CalculateEuclidsAlgorithm(numberOne,
                                                                                  numberTwo, numberThree).ToString();
                }
                else
                {
                    _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
                }
            }
            if (checkBoxFour.IsChecked ?? false)
            {
                if (int.TryParse(textBoxNumberOne.Text, out int numberOne)
                    & int.TryParse(textBoxNumberTwo.Text, out int numberTwo)
                    & int.TryParse(textBoxNumberThree.Text, out int numberThree)
                    & int.TryParse(textBoxNumberFour.Text, out int numberFour))
                {
                    textBoxResult.Text = CalculatorNod.CalculateEuclidsAlgorithm(numberOne,
                                                                                   numberTwo,
                                                                                   numberThree,
                                                                                   numberFour).ToString();
                }
                else
                {
                    _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
                }
            }
            if (checkBoxFive.IsChecked ?? false)
            {
                if (int.TryParse(textBoxNumberOne.Text, out int numberOne)
                    & int.TryParse(textBoxNumberTwo.Text, out int numberTwo)
                    & int.TryParse(textBoxNumberThree.Text, out int numberThree)
                    & int.TryParse(textBoxNumberFour.Text, out int numberFour)
                    & int.TryParse(textBoxNumberFive.Text, out int numberFive))
                {
                    textBoxResult.Text = CalculatorNod.CalculateEuclidsAlgorithm(numberOne,
                                                                                   numberTwo,
                                                                                   numberThree,
                                                                                   numberFour,
                                                                                   numberFive).ToString();
                }
                else
                {
                    _ = MessageBox.Show("Данные не введены или введены неверно",
                                        "Внимание");
                }
            }
        }

        private void ButtonSteinCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxNumberOne.Text, out int numberOne) & int.TryParse(textBoxNumberTwo.Text, out int numberTwo))
            {
                textBoxResult.Text = new string("НОД: "
                                                + CalculatorNod.CalculateSteinAlgorithm(numberOne, numberTwo, out TimeSpan time).ToString()
                                                + " время выполнения: "
                                                + time.TotalMilliseconds.ToString());
            }
            else
            {
                _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
            }
        }

        private void ButtonCompareAlgorithms_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxNumberOne.Text, out int numberOne) & int.TryParse(textBoxNumberTwo.Text, out int numberTwo))
            {

                textBoxResult.Text = CalculatorNod.CalculateSteinAlgorithm(numberOne, numberTwo, out TimeSpan timeSteinAlgorithm).ToString();
                _ = CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, out TimeSpan timeEuclidsAlgorithm);
                Diagram.BuildDiagram(diagramGrid,
                                       timeEuclidsAlgorithm.TotalMilliseconds,
                                       timeSteinAlgorithm.TotalMilliseconds,
                                       "Алгоритм Евклида",
                                       "Алгоритм Стейна");
            }
            else
            {
                _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
            }
        }

        private void ButtonCompareAlgorithmsVertical_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxNumberOne.Text, out int numberOne) & int.TryParse(textBoxNumberTwo.Text, out int numberTwo))
            {

                textBoxResult.Text = CalculatorNod.CalculateSteinAlgorithm(numberOne, numberTwo, out TimeSpan timeSteinAlgorithm).ToString();
                _ = CalculatorNod.CalculateEuclidsAlgorithm(numberOne, numberTwo, out TimeSpan timeEuclidsAlgorithm);
                Diagram.BuildDiagram(diagramGrid,
                                       timeEuclidsAlgorithm.TotalMilliseconds,
                                       timeSteinAlgorithm.TotalMilliseconds,
                                       "Алгоритм Евклида",
                                       "Алгоритм Стейна",
                                       true,
                                       Colors.Coral,
                                       Colors.Gold);
            }
            else
            {
                _ = MessageBox.Show("Данные не введены или введены неверно", "Внимание");
            }
        }
    }
}
