using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SelectedOperator Operator;
        double lastNumber, result;
        public MainWindow()
        {
            InitializeComponent();

            Resultlabel.Content = "0";

            EqualButton.Click += EqualButton_Click;

            DotButton.Click += DotButton_Click;
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (Resultlabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                Resultlabel.Content = $"{Resultlabel.Content}.";
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double NewNumber;

            if (double.TryParse(Resultlabel.Content.ToString(), out NewNumber))
            {
                switch(Operator)
                {
                    case SelectedOperator.Addition:
                        result=SimpleMaths.Add(lastNumber, NewNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMaths.Div(lastNumber, NewNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMaths.Mult(lastNumber, NewNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMaths.Sub(lastNumber, NewNumber);
                        break;
                      
                }
                Resultlabel.Content=result.ToString();
            }

        }

        private void OperationButton_Click(object sender,RoutedEventArgs e)
        {
            if (double.TryParse(Resultlabel.Content.ToString(), out lastNumber))
            {
                Resultlabel.Content = "0";
            }

            if (sender == PlusButton)
                Operator = SelectedOperator.Addition;
            if (sender == MinusButton)
                Operator = SelectedOperator.Substraction;
            if (sender == DivideButton)
                Operator = SelectedOperator.Division;
            if (sender == MultiButton)
                Operator = SelectedOperator.Multiplication;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            //int SelectedVal = 0;
            //if (sender == OneButton)
            //    SelectedVal = 1;
            //if (sender == ZeroButton)
            //    SelectedVal = 0;
            //if (sender == TwoButton)
            //    SelectedVal = 2;
            //if (sender == ThreeButton)
            //    SelectedVal = 3;
            //if (sender == FourButton)
            //    SelectedVal = 4;
            //if (sender == FiveButton)
            //    SelectedVal = 5;
            //if (sender == SixButton)
            //    SelectedVal = 6;
            //if (sender == SevenButton)
            //    SelectedVal = 7;
            //if (sender == EightButton)
            //    SelectedVal = 8;
            //if (sender == NineButton)
            //    SelectedVal = 9;

            int SelectedVal = 
                int.Parse((sender as Button).Content.ToString());

            if (Resultlabel.Content.ToString() == "0")
            {
                Resultlabel.Content = $"{SelectedVal}";
            }
            else
            {
                Resultlabel.Content = $"{Resultlabel.Content}{SelectedVal}";
            }

        } 


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Resultlabel.Content = 0;
        }
    }


    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMaths
    {
        public static double Add(double a,double b)
        {
            return a + b;
        }

        public static double Sub(double a, double b)
        {
            return a - b;
        }

        public static double Mult(double a, double b)
        {
            return a * b;
        }

        public static double Div(double a, double b)
        {
            if (b == 0)
            {
                MessageBox.Show("Division by 0 is not suppported","Wrong Operation",MessageBoxButton.OK,MessageBoxImage.Warning);
                return 0;
            }

            return a / b;
        }
    }

}
