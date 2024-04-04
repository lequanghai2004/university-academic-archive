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
    public partial class HandleAccount_Form : Form
    {
        private bool _isCreateAcc;
        public HandleAccount_Form(bool isCreateAcc)
        {
            InitializeComponent();
            _isCreateAcc = isCreateAcc;
        }

        private void HandleAccount_Load(object sender, EventArgs e)
        {
            if (_isCreateAcc)
            {
                title_Label.Text = "CREATE NEW ACCOUNT";
            }
            else // drop account
            {
                title_Label.Text = "DELETE ACCOUNT";
                btn.Location = new Point(280, 200);
                btn.Text = "delete account";
                tableLayoutPanel.Hide();
                Size = new Size(800, 350);
            }
        }
        private async void btn_Click(object sender, EventArgs ev)
        {
            string action = _isCreateAcc ? "creating" : "deleting";
            // show a noti while processing, close when done
            NotiForm notiForm = new NotiForm();
            notiForm.Text = "Processing ...";
            notiForm.SetNotiLabelTxt(action + " account ...");

            try
            {
                Task task = !_isCreateAcc
                    ? UserHandler.Instance.DropRecord(username_TxtBox.Text)
                    : UserHandler.Instance.AddUser(username_TxtBox.Text, password_TxtBox.Text,
                        priority_TxtBox.Text, fullname_TxtBox.Text,
                        email_TxtBox.Text, phoneNo_TxtBox.Text);

                notiForm.Show();
                await task;
                notiForm.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show("App layer error when " + action + " account: " + e.Message);
            }
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Filter out control characters, characters with special meaning in SQL
            string filteredText = new string(textBox.Text
                .Where(c => !char.IsControl(c) && c != '\'' && !char.IsSurrogate(c))
                .ToArray());

            // Filter space if the current text box is not 'fullname'
            if (!textBox.Name.Equals("fullname_TxtBox", StringComparison.OrdinalIgnoreCase))
            {
                filteredText = new string(textBox.Text.Where(c => c != ' ').ToArray());
            }

            // Update the text in the text box
            textBox.Text = filteredText;

            // Set the cursor position to the end
            textBox.SelectionStart = textBox.Text.Length;
        }
    }
}
