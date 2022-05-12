using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace _3._Methods
{
    public static class Diagram
    {
        public static void BuildDiagram(Grid graficGrid,
                                          double valueOne,
                                          double valueTwo,
                                          string nameValueOne,
                                          string nameValueTwo,
                                          bool verticalOrientation = false,
                                          Color colorGraficValueOne = default,
                                          Color colorGraficValueTwo = default)
        {
            graficGrid.Children.Clear();
            graficGrid.ColumnDefinitions.Clear();
            graficGrid.RowDefinitions.Clear();
            if (colorGraficValueOne == default)
            {
                colorGraficValueOne = Colors.Blue;
            }
            if (colorGraficValueTwo == default)
            {
                colorGraficValueTwo = Colors.Green;
            }
            graficGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            graficGrid.VerticalAlignment = VerticalAlignment.Stretch;
           
            Rectangle rectangleValueOne = new Rectangle
            {
                Fill = new SolidColorBrush(colorGraficValueOne),
                Stretch = Stretch.Fill
            };
            Rectangle rectangleValueTwo = new Rectangle
            {
                Fill = new SolidColorBrush(colorGraficValueTwo),
                Stretch = Stretch.Fill
            };
            TextBlock blockValueOne = new TextBlock
            {
                Text = valueOne.ToString(),
                TextWrapping = TextWrapping.Wrap
            };
            TextBlock blockValueTwo = new TextBlock
            {
                Text = valueTwo.ToString(),
                TextWrapping = TextWrapping.Wrap
            };
            TextBlock blockNameValueOne = new TextBlock
            {
                Text = nameValueOne,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap
            };
            TextBlock blockNameValueTwo = new TextBlock
            {
                Text = nameValueTwo,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap

            };
            Grid gridValueOne = new Grid();
            Grid gridValueTwo = new Grid();
            if (!verticalOrientation)
            {
                blockValueOne.VerticalAlignment = VerticalAlignment.Bottom;
                blockValueOne.HorizontalAlignment = HorizontalAlignment.Center;
                blockValueTwo.VerticalAlignment = VerticalAlignment.Bottom;
                blockValueTwo.HorizontalAlignment = HorizontalAlignment.Center;
                gridValueOne.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1 - (valueOne /
                    (valueOne + valueTwo)), GridUnitType.Star)
                });
                gridValueOne.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(valueOne /
                    (valueOne + valueTwo), GridUnitType.Star)
                });
                Grid.SetColumn(gridValueOne, 1);
                Grid.SetRow(gridValueOne, 1);
                gridValueTwo.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1 - (valueTwo /
                    (valueOne + valueTwo)), GridUnitType.Star)
                });
                gridValueTwo.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(valueTwo /
                    (valueOne + valueTwo), GridUnitType.Star)
                });
                Grid.SetColumn(gridValueTwo, 3);
                Grid.SetRow(gridValueTwo, 1);
                Grid.SetColumn(blockNameValueOne, 1);
                Grid.SetRow(blockNameValueOne, 2);
                Grid.SetColumn(blockNameValueTwo, 3);
                Grid.SetRow(blockNameValueTwo, 2);
                _ = graficGrid.Children.Add(gridValueOne);
                _ = graficGrid.Children.Add(gridValueTwo);
                _ = graficGrid.Children.Add(blockNameValueOne);
                _ = graficGrid.Children.Add(blockNameValueTwo);
                Grid.SetRow(blockValueOne, 0);
                Grid.SetRow(blockValueTwo, 0);
                Grid.SetRow(rectangleValueOne, 1);
                Grid.SetRow(rectangleValueTwo, 1);
                _ = gridValueOne.Children.Add(rectangleValueOne);
                _ = gridValueTwo.Children.Add(rectangleValueTwo);
                _ = gridValueOne.Children.Add(blockValueOne);
                _ = gridValueTwo.Children.Add(blockValueTwo);
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.5, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0.5, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition());
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(3.0, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            else
            {
                blockValueOne.VerticalAlignment = VerticalAlignment.Center;
                blockValueOne.HorizontalAlignment = HorizontalAlignment.Left;
                blockValueTwo.VerticalAlignment = VerticalAlignment.Center;
                blockValueTwo.HorizontalAlignment = HorizontalAlignment.Left;
                gridValueOne.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(valueOne /
                    (valueOne + valueTwo), GridUnitType.Star)
                });
                gridValueOne.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1 - (valueOne /
                    (valueOne + valueTwo)), GridUnitType.Star)
                });
                Grid.SetColumn(gridValueOne, 1);
                Grid.SetRow(gridValueOne, 1);
                gridValueTwo.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(valueTwo /
                    (valueOne + valueTwo), GridUnitType.Star)
                });
                gridValueTwo.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1 - valueTwo /
                    (valueOne + valueTwo), GridUnitType.Star)
                });
                Grid.SetColumn(gridValueTwo, 1);
                Grid.SetRow(gridValueTwo, 3);
                Grid.SetColumn(blockValueOne, 1);
                Grid.SetColumn(blockValueTwo, 1);
                Grid.SetColumn(rectangleValueOne, 0);
                Grid.SetColumn(rectangleValueTwo, 0);
                _ = gridValueOne.Children.Add(rectangleValueOne);
                gridValueTwo.Children.Add(rectangleValueTwo);
                _ = gridValueOne.Children.Add(blockValueOne);
                _ = gridValueTwo.Children.Add(blockValueTwo);
                _ = graficGrid.Children.Add(gridValueOne);
                _ = graficGrid.Children.Add(gridValueTwo);
                Grid.SetColumn(blockNameValueOne, 0);
                Grid.SetRow(blockNameValueOne, 1);
                Grid.SetColumn(blockNameValueTwo, 0);
                Grid.SetRow(blockNameValueTwo, 3);
                _ = graficGrid.Children.Add(blockNameValueOne);
                _ = graficGrid.Children.Add(blockNameValueTwo);
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2.0, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.5, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition());
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(3.0, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10.0, GridUnitType.Star) });
                graficGrid.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}
