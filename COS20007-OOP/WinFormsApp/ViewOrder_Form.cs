using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class ViewOrder_Form : Form
    {
        private Form[] forms;
        private User _user;
        public ViewOrder_Form(User user)
        {
            InitializeComponent();

            _user = user;

            forms = new Form[3]
            {
                new Admin_Form(user),
                new Staff_Form(user),
                new Customer_Form(user),
            };



        }
        public void ResetPanel()
        {
            customer_Panel.Hide();
            foreach (Form form in forms) form.Hide();
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            MenuStripConsole.User = _user;

            if (_user.Priority >= 100)
            {
                createAcc_ToolStripMenuItem.Enabled = true;
                delAcc_ToolStripMenuItem.Enabled = true;
            }

            //ResetPanel();
            //forms[2].Show();    
        }
        private void CheckDateValidity(object sender, EventArgs ev)
        {
            if (fromMonth_ComBox.SelectedItem == null ||
                fromYear_ComBox.SelectedItem == null ||
                toMonth_ComBox.SelectedItem == null ||
                toYear_ComBox.SelectedItem == null) return;

            // Get the selected month and year values from ComboBoxes
            int fromMonth = (int)(Month)Enum.Parse(typeof(Month), fromMonth_ComBox.SelectedItem.ToString());
            int fromYear = Convert.ToInt32(fromYear_ComBox.SelectedItem);

            int toMonth = (int)(Month)Enum.Parse(typeof(Month), toMonth_ComBox.SelectedItem.ToString());
            int toYear = Convert.ToInt32(toYear_ComBox.SelectedItem);

            // Create DateTime objects for the selected dates
            // Assume day is 1 for simplicity
            DateTime fromDate = new DateTime(fromYear, fromMonth, 1);
            DateTime toDate = new DateTime(toYear, toMonth, 1);

            // Compare the DateTime objects
            if (toDate <= fromDate)
            {
                //MessageBox.Show("The 'to' date must be later than the 'from' date.");

                // Optionally, adjust the 'to' date to ensure it is later than the 'from' date
                toMonth_ComBox.SelectedIndex = fromMonth_ComBox.SelectedIndex;
                toYear_ComBox.SelectedItem = fromYear_ComBox.SelectedItem;
            }
        }
        private void reset_Btn_Click(object sender, EventArgs ev)
        // orders: id, customer_id, staff_id, date_time, approach
        {
            string query = "SELECT users.fullname AS customer, date_time, " +
                "CASE WHEN approach = 1 THEN 'online' WHEN approach = 2 THEN 'offline' ELSE 'null' END AS method " +
                "FROM orders JOIN users ON orders.customer_id = users.id";


            int orderApproach;
            switch (orderType_GrpBox.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked))
            {
                case RadioButton onl_RadBtn when onl_RadBtn.Name == "onl_RadBtn":
                    // Code for 'onl_RadBtn' selected
                    orderApproach = 1;
                    break;
                case RadioButton offl_RadBtn when offl_RadBtn.Name == "offl_RadBtn":
                    // Code for 'offl_RadBtn' selected
                    orderApproach = 2;
                    break;
                case RadioButton all_RadBtn when all_RadBtn.Name == "all_RadBtn":
                    // Code for 'all_RadBtn' selected
                    orderApproach = 0;
                    break;
                default:
                    // Default case when no radio button is selected or an unexpected case
                    orderApproach = 0;
                    break;
            }

            if (orderApproach != 0)
            {
                query += " WHERE 'approach' = " + orderApproach.ToString();
            }

            query += ";";
            DisplayData(query, dataGridView1);
        }
        private async void DisplayData(string query, DataGridView dtgv)
        {
            try
            {
                Task<DataTable> processQuery = SqlHandler.Instance.GetTable(query);

                // show a noti while processing, close when done
                NotiForm notiForm = new NotiForm();
                notiForm.Text = "Processing ...";
                notiForm.SetNotiLabelTxt("Loading data ...");
                notiForm.Show();

                dtgv.DataSource = await processQuery;
                notiForm.Hide();
                notiForm.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("App layer failed: " + e.Message + e.StackTrace);
            }
        }
        private void delAcc_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuStripConsole.delAcc_ToolStripMenuItem_Click(this);
        }

        private void createAcc_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuStripConsole.createAcc_ToolStripMenuItem_Click(this);
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuStripConsole.newOrder_ToolStripMenuItem_Click(this);
        }
    }
}
