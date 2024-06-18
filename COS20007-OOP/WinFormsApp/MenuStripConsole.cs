using System.Data;
using System.Windows.Forms;

namespace WinFormsApp
{
    public static class MenuStripConsole
    {
        private static User user;
        public static User User 
        { 
            set 
            { 
                user = value;
            } 
        }
        public static void delAcc_ToolStripMenuItem_Click(Form form)
        {
            form.Hide();
            new HandleAccount_Form(false).ShowDialog();
            form.Show();
        }
        public static void createAcc_ToolStripMenuItem_Click(Form form)
        {
            form.Hide();
            new HandleAccount_Form(true).ShowDialog();
            form.Show();
        }
        public static void newOrder_ToolStripMenuItem_Click(Form form)
        {
            form.Hide();
            new NewOrder_Form().ShowDialog();
            form.Show();
        }
    }
}
