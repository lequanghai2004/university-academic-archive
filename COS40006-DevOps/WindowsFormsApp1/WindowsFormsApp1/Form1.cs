using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox CurrentOperandTextBox { get; set; }
        private ClassLibrary1.Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            InitializeButtons();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Set form border style to fixed
            this.MaximizeBox = false; // Disable maximize button

            CurrentOperandTextBox = operand1_textBox;
            calculator = new ClassLibrary1.Calculator();
        }

        private void InitializeButtons()
        {
            int numRows = 3; 
            int numCols = 3;

            int buttonWidth = numbers_flowLayoutPanel.ClientSize.Width / numCols - 6;
            int buttonHeight = numbers_flowLayoutPanel.ClientSize.Height / numRows - 6; 

            for (int i = 1; i <= numRows * numCols; i++)
            {
                Button button = new Button
                {
                    Text = i.ToString(),
                    Tag = i,
                    Width = buttonWidth,
                    Height = buttonHeight,
                };
                button.Click += number_button_Click;
                numbers_flowLayoutPanel.Controls.Add(button);
            }
        }

        private void number_button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                CurrentOperandTextBox.Text = clickedButton.Text + CurrentOperandTextBox.Text;
            }
        }

        private void operator_button_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                operator_textBox.Text = clickedButton.Text;
            }
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            operand1_textBox.Text = "";
            operand2_textBox.Text = "";
            operator_textBox.Text = "";
            CurrentOperandTextBox = operand1_textBox;
            resultValue_textBox.Text = "";
        }

        private void operand1_textBox_Click(object sender, EventArgs e)
        {
            CurrentOperandTextBox = operand1_textBox;
        }

        private void operand2_textBox_Click(object sender, EventArgs e)
        {
            CurrentOperandTextBox = operand2_textBox;
        }

        private void equal_button_Click(object sender, EventArgs e)
        {
            if (operand1_textBox.Text == "" || operand2_textBox.Text == "")
            {
                return;
            }

            int operand1 = Convert.ToInt32(operand1_textBox.Text);
            int operand2 = Convert.ToInt32(operand2_textBox.Text);

           resultValue_textBox.Text = calculator.Calculate(operand1, operand2, operator_textBox.Text).ToString();
        }
    }
}
