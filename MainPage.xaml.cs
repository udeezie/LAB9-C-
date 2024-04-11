using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    public partial class MainPage : ContentPage
    {
        double firstNumber;
        double secondNumber;
        string currentOperation;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var number = button.Text;

            if (DisplayEntry.Text == "0" || currentOperation == "=")
            {
                DisplayEntry.Text = number;
                if (currentOperation == "=")
                {
                    firstNumber = 0;
                    currentOperation = null;
                }
            }
            else
            {
                DisplayEntry.Text += number;
            }
        }

        private void OnSelectOperator(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentOperation = button.Text;
            firstNumber = double.Parse(DisplayEntry.Text);
            DisplayEntry.Text = "0";
        }

        private void OnCalculateResult(object sender, EventArgs e)
        {
            secondNumber = double.Parse(DisplayEntry.Text);
            DisplayEntry.Text = CalculateResult().ToString();
            currentOperation = "=";
        }

        private double CalculateResult()
        {
            switch (currentOperation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return secondNumber != 0 ? firstNumber / secondNumber : 0; 
                default:
                    return secondNumber;
            }
        }

        private void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentOperation = null;
            DisplayEntry.Text = "0";
        }
    }
}
