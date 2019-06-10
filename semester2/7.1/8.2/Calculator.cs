using System;
using System.Windows.Forms;

namespace H7T1
{
    /// <summary>
    /// Simple calculator with GUI
    /// </summary>
    public partial class Calculator : Form
    {
        private float currentNumber;
        private float countedNumber;
        private string operation;
        private string nextOperation;

        /// <summary>
        /// Default constructor. Initializes components
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
            countedString.Text = "";
            operation = "";
            nextOperation = "";
        }

        private void ButtonNumberClick(object sender, EventArgs e)
        {
            currentString.Text += (sender as Button).Text;
            countedString.Text += (sender as Button).Text;
        }

        private void ButtonOperationClick(object sender, EventArgs e)
        {
            if (float.TryParse(currentString.Text, out currentNumber))
            {
                operation = nextOperation;
                nextOperation = (sender as Button).Text;
                if (operation != "")
                {
                    try
                    {
                        countedNumber = Counter.Count(countedNumber, currentNumber, operation);
                    }
                    catch (DivideByZeroException)
                    {
                        currentString.Text = "ERROR!";
                        countedString.Text = "";
                        operation = "";
                        nextOperation = "";
                    }
                }
                else
                {
                    countedNumber = currentNumber;
                }
                countedString.Text = countedNumber.ToString() + " " + nextOperation + " ";
                currentString.Text = "";
            }
        }

        private void EqualsButtonClick(object sender, EventArgs e)
        {
            operation = nextOperation;
            nextOperation = "";
            if (float.TryParse(currentString.Text, out currentNumber))
            {
                countedNumber = Counter.Count(countedNumber, currentNumber, operation);
                countedString.Text = countedNumber.ToString();
                currentString.Text = countedNumber.ToString();
            }
        }

        private void ChangeSignClick(object sender, EventArgs e)
        {
            if (currentString.Text != "")
            {
                if (currentString.Text[0] == '-')
                {
                    currentString.Text = currentString.Text.Remove(0, 1);
                }
                else
                {
                    currentString.Text = "-" + currentString.Text;
                }
            }
        }

        private void BackspaceClick(object sender, EventArgs e)
        {
            if (currentString.Text != "")
            {
                currentString.Text = currentString.Text.Remove(currentString.Text.Length - 1, 1);
                countedString.Text = countedString.Text.Remove(countedString.Text.Length - 1, 1);
            }
        }

        private void ClearCurrentClick(object sender, EventArgs e)
        {
            currentString.Text = "";
            countedString.Text = countedNumber.ToString() + " " + nextOperation + " ";
        }

        private void ClearAllClick(object sender, EventArgs e)
        {
            currentString.Text = "";
            countedString.Text = "";
            operation = "";
            nextOperation = "";
            currentNumber = 0;
            countedNumber = 0;
        }
    }
}