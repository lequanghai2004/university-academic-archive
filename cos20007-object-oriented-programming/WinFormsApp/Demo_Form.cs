using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Demo_Form : Form
    {
        public Demo_Form()
        {
            InitializeComponent();
        }

        private void Demo_Form_Load(object sender, EventArgs e)
        {
            Label nameLabel = new Label();
            nameLabel.Text = "label1";
            nameLabel.AutoSize = true;

            nameLabel.Location = new Point(50, 50);

            Controls.Add(nameLabel);
        }
    }
}
