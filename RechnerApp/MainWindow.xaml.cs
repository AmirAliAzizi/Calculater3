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
using System.Collections;
using System.Linq.Expressions;
using System.Data;
using System.Security.Policy;

namespace RechnerApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string calStr = "";
        double calResulst;
        ArrayList calculatArrayList = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
        }
        


        public void DisplayNumberUpdater(double inputNumber)
        {
            calStr += inputNumber.ToString();
            ShowItInTextBox();
        }
        public void CommaAfterZeroOrAfterNumber()
        {
            if (calStr.Length == 0)
            {
                calStr += "0" + ".";
                ShowItInTextBox();
            }
            else
            {
                calStr += ".";
                ShowItInTextBox();
            }
        }
        public void ClearAndUpgradeDisplay()
        {
            ShowItInTextBox();
            ClearCalStr();
        }
        private void ShowItInTextBox()
        {
            displayTextBox.Text = calStr;
        }
        private void ShowResultInTextBox()
        {
            displayTextBox.Text = calResulst.ToString();
        }
        private void ClearCalStr()
        {
            calStr = "";
        }

        //Numbers_Clicked
        private void Num1_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(1);
        }
        private void Num2_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(2);
        }
        private void Num3_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(3);
        }
        private void Num4_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(4);
        }
        private void Num5_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(5);
        }
        private void Num6_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(6);
        }
        private void Num7_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(7);
        }
        private void Num8_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(8);
        }
        private void Num9_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(9);
        }
        private void Num0_Clicked(object sender, RoutedEventArgs e)
        {
            DisplayNumberUpdater(0);
        }
        private void Punkt_Clicked(object sender, RoutedEventArgs e)
        {
            CommaAfterZeroOrAfterNumber();
        }



        // Oprator_Clicked
        private void CButton_Clicked(object sender, RoutedEventArgs e)
        {
            ClearAndUpgradeDisplay();
        }
        private void Plus_Clicked(object sender, RoutedEventArgs e)
        {
            calculatArrayList.Add(calStr);
            calculatArrayList.Add("+");
            ClearAndUpgradeDisplay();
        }
        private void Minus_Clicked(object sender, RoutedEventArgs e)
        {
            calculatArrayList.Add(calStr);
            calculatArrayList.Add("-");
            ClearAndUpgradeDisplay();
        }
        private void Multi_Clicked(object sender, RoutedEventArgs e)
        {
            calculatArrayList.Add(calStr);
            calculatArrayList.Add("*");
            ClearAndUpgradeDisplay();

        }
        private void Divi_Clicked(object sender, RoutedEventArgs e)
        {
            calculatArrayList.Add(calStr);
            calculatArrayList.Add("/");
            ClearAndUpgradeDisplay();

        }
        private void Percent_Clicked(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(calStr);
            displayTextBox.Text = (num/100).ToString();
            ClearCalStr();
        }
        private void Pow_Clicked(object sender, RoutedEventArgs e)
        {
            double num = double.Parse(calStr);
            displayTextBox.Text = (Math.Pow(num,2 )).ToString();
            ClearCalStr();
        }
        private void PlusOrMinus_Clicked(object sender, RoutedEventArgs e)
        {
            if(calStr.Contains("-") == false)
            {
                calStr = "-" + calStr;
                ShowItInTextBox();
            }
            else
            {
                calStr = calStr.Remove(0,1);
                ShowItInTextBox();
            }
        }
        private void DotBeforeDashRule( ArrayList calculatArrayList)
        {
            string num1;
            string num2;
            string calOperator;
            if (calculatArrayList.Contains("*") == true)
            {
                calOperator = calculatArrayList[calculatArrayList.IndexOf("*")].ToString();
                num1 = calculatArrayList[calculatArrayList.IndexOf("*") - 1].ToString();
                num2 = calculatArrayList[calculatArrayList.IndexOf("*") + 1].ToString();
                CalculatOprat(double.Parse(num1), double.Parse(num2), calOperator);
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf("*"));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num1));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num2));
                if (calculatArrayList.Count > 3)
                {
                    DotBeforeDashRule(calculatArrayList);
                }
                else if (calculatArrayList.Count == 3)
                {
                    CalJusttwoNumbers(calculatArrayList);
                }
            }
            else if (calculatArrayList.Contains("/") == true)
            {

                calOperator = calculatArrayList[calculatArrayList.IndexOf("/")].ToString();
                num1 = calculatArrayList[calculatArrayList.IndexOf("/") - 1].ToString();
                num2 = calculatArrayList[calculatArrayList.IndexOf("/") + 1].ToString();
                CalculatOprat(double.Parse(num1), double.Parse(num2), calOperator);
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf("/"));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num1));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num2));
                if (calculatArrayList.Count > 3)
                {
                    DotBeforeDashRule(calculatArrayList);
                }
                else if (calculatArrayList.Count == 3)
                {
                    CalJusttwoNumbers(calculatArrayList);
                }
            }
            else if (calculatArrayList.Contains("+") == true)
            {

                calOperator = calculatArrayList[calculatArrayList.IndexOf("+")].ToString();
                num1 = calculatArrayList[calculatArrayList.IndexOf("+") - 1].ToString();
                num2 = calculatArrayList[calculatArrayList.IndexOf("+") + 1].ToString();
                CalculatOprat(double.Parse(num1), double.Parse(num2), calOperator);
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf("+"));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num1));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num2));
                if (calculatArrayList.Count > 3)
                {
                    DotBeforeDashRule(calculatArrayList);
                }
                else if (calculatArrayList.Count == 3)
                {
                    CalJusttwoNumbers(calculatArrayList);
                }
            }
            else if (calculatArrayList.Contains("-") == true)
            {

                calOperator = calculatArrayList[calculatArrayList.IndexOf("-")].ToString();
                num1 = calculatArrayList[calculatArrayList.IndexOf("-") - 1].ToString();
                num2 = calculatArrayList[calculatArrayList.IndexOf("-") + 1].ToString();
                CalculatOprat(double.Parse(num1), double.Parse(num2), calOperator);
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf("-"));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num1));
                calculatArrayList.RemoveAt(calculatArrayList.IndexOf(num2));
                if (calculatArrayList.Count > 3)
                {
                    DotBeforeDashRule(calculatArrayList);
                }
                else if (calculatArrayList.Count == 3)
                {
                    CalJusttwoNumbers(calculatArrayList);
                }
            }

        }
        private void CalJusttwoNumbers(ArrayList calculatArrayList )
        {
            double num1 = double.Parse((string)calculatArrayList[0]);
            double num2 = double.Parse((string)calculatArrayList[2]);
            string calOperator = (string)calculatArrayList[1];
            CalculatOprat(num1, num2, calOperator);
            ClearCalStr();
            calculatArrayList.Clear();
        }
        private void CalculatOprat(double num1, double num2, string calOperator)
        {
            switch (calOperator)
            {
                case "+":
                    calResulst = num1 + num2;
                    ShowResultInTextBox();

                    break;
                case "-":
                    calResulst = num1 - num2;
                    ShowResultInTextBox();
                    break;
                case "*":
                    calResulst = num1 * num2;
                    ShowResultInTextBox();
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        calResulst = num1 / num2;
                        ShowResultInTextBox();
                    }
                    else
                    {
                        MessageBox.Show("You are not allow to divided by 0 !!! ;)");
                        ClearCalStr();
                    }
                    break;

                default:
                    break;
            }
            calculatArrayList.Insert(calculatArrayList.IndexOf(num1.ToString()), calResulst.ToString());

            displayTextBox.Text = calResulst.ToString();
        }
        private void IsEqualTo_Clicked(object sender, RoutedEventArgs e)
        {
            calculatArrayList.Add(calStr);
            if (calculatArrayList.Count == 3)
            {
                try
                {
                    CalJusttwoNumbers(calculatArrayList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    calculatArrayList.Clear();
                    ClearAndUpgradeDisplay();
                }
               
                
            }
            else if (calculatArrayList.Count > 3)
            {
                //try
                //{
                    DotBeforeDashRule(calculatArrayList);
                //}
                //catch (Exception ex)
                //{
                  //  MessageBox.Show(ex.ToString());
                   // calculatArrayList.Clear();
                    //ClearAndUpgradeDisplay();
                //}
               
                
            }
        }

        /// <summary>
        /// Usefull staff
        /// </summary>
        static void Charcheck()
        {
            String str = "abcdefgh";
            Char value = 'c';
            Boolean result = str.Contains(value);
            MessageBox.Show(result.ToString());
        }
        public void SpiltTheString()
        {
            String str = "Geeks, For Geeks";

            String[] spearator = { "s, ", "For" };
            Int32 count = 2;

            // using the method
            String[] strlist = str.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                MessageBox.Show(s);
            }
        }
    }
}
