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
    public partial class NotiForm : Form
    {
        public NotiForm()
        {
            InitializeComponent();
        }
        public void SetNotiLabelTxt(string value)
        {
            noti_Label.Text = value;
        }
        private void NotiForm_Load(object sender, EventArgs e)
        {
            noti_Label.Left = (this.ClientSize.Width - noti_Label.Width) / 2;
            noti_Label.Top = (this.ClientSize.Height - noti_Label.Height) / 2;
        }

        private void noti_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
