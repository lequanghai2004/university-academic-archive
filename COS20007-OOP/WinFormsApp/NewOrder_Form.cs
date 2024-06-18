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
    public partial class NewOrder_Form : Form
    {
        private List<Item> _items = new List<Item>();
        private List<NumericUpDown> _amounts = new List<NumericUpDown>();
        public NewOrder_Form()
        {
            InitializeComponent();


        }

        private async void NewOrder_Form_Load(object sender, EventArgs ev)
        {
            try
            {
                string query = "SELECT * FROM items";
                Task<DataTable> processQuery = SqlHandler.Instance.GetTable(query);

                // show a noti while processing, close when done
                NotiForm notiForm = new NotiForm();
                notiForm.Text = "Processing ...";
                notiForm.TopMost = true;
                notiForm.SetNotiLabelTxt("Loading data ...");
                notiForm.Show();
                DataTable table = await processQuery;
                notiForm.Hide();

                int id; string title; string types; string options; decimal priceVnd;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];

                    id = (int)row["id"];
                    title = row["title"] != DBNull.Value ? (string)row["title"] : "";
                    types = row["types"] != DBNull.Value ? (string)row["types"] : "";
                    options = row["options"] != DBNull.Value ? (string)row["options"] : "";
                    priceVnd = (decimal)row["price_vnd"];

                    _items.Add(new Item(id, title, types, options, priceVnd));
                }


                int topDistance = 1;
                foreach (Item item in _items)
                {
                    Label nameLabel = new Label();
                    nameLabel.Text = item.Title;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new Point(100, 100 + topDistance * 50);

                    NumericUpDown amountNumericUpDown = new NumericUpDown();
                    amountNumericUpDown.Minimum = 0;
                    amountNumericUpDown.Value = 0;
                    amountNumericUpDown.Location = new Point(400, 100 + topDistance * 50);
                    _amounts.Add(amountNumericUpDown);

                    // Attach the ValueChanged event handler
                    amountNumericUpDown.ValueChanged += (s, ev) =>
                    {
                        // Update the total label whenever any NumericUpDown value changes
                        UpdateTotalLabel();
                    };

                    Controls.Add(nameLabel);
                    Controls.Add(amountNumericUpDown);

                    topDistance++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception on NewOrder creation: " + e.Message + e.StackTrace);
            }
        }
        private void UpdateTotalLabel()
        {
            // Implement your logic to update the total label based on NumericUpDown values
            // For example, you can iterate through NumericUpDown controls and sum their values
            decimal totalValue = 0.0m;
            

            // Iterate through both lists simultaneously and calculate the total
            for (int i = 0; i < _items.Count && i < _amounts.Count; i++)
            {
                totalValue += _items[i].CostInVnd * (decimal)_amounts[i].Value;

                
            }

            // Update the total label
            total_Label.Text = $"Total: {totalValue:C}";
        }
        private void btnDynLabel_Click(object sender, EventArgs e)
        {
            string query;

            query = "INSERT INTO orders () VALUES ();";

            for (int i = 0; i < _items.Count; i++)
            {

            }

            // show a noti while processing, close when done
            NotiForm notiForm = new NotiForm();
            notiForm.SetNotiLabelTxt("Loading data ...");
            notiForm.Show();



            query = "INSERT INTO order_items (order_id, item_id, amount) VALUES ";

            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];
                string amount = _amounts[i].ToString();

                if (_amounts[i].Value > 0)
                {
                    query += $"({item.Title},{item.Id},{amount}),";
                }
            }

            query += ";";


            notiForm.Hide();
        }

        private void order_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
            }
        }

        // Helper methods for database operations

        private async Task<int> InsertOrder(int customerId, int staffId, DateTime dateTime, int approach)
        {
            object lastOrderId = await SqlHandler.Instance.GetScalar("SELECT MAX(id) FROM orders;");


            // Handle the case where the result is DBNull.Value or null
            lastOrderId = lastOrderId != null && lastOrderId != DBNull.Value ? Convert.ToInt32(lastOrderId) : throw new Exception();


            return await new Task<int>(() => { return 0; });
        }

        private void InsertOrderItem(int orderId, int itemId, int options, int amount)
        {
            // Implement the logic to insert data into the 'order_items' table
            // Use your preferred method (e.g., Dapper, Entity Framework, SqlCommand)
        }
    }
}