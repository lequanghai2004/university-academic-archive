using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    public class ItemHandler : EntityHandler
    // singleton class
    // responsible for add or drop and validate user account
    {
        private static ItemHandler? _instance;
        public static ItemHandler Instance
        {
            get { return _instance == null ? new ItemHandler() : _instance; }
        }
        private ItemHandler() : base("items", "title") { }
        public async void AddItem(params object[] data)
        {
            try
            {
                string title = (string)data[0];
                string desc = (string)data[1];
                string types = (string)data[2];
                string options = (string)data[3];
                float price = (float)data[4];

                await AddRecord(("title", title),
                    ("description", desc),
                    ("types", types),
                    ("options", options),
                    ("price_vnd", price));
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("Item handler: Invalid input argument: " + e.Message + e.StackTrace);
                return;
            }
        }
    }
}
