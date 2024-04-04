using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp
{
    public partial class LogIn_Form : Form
    {
        private bool formIsInProc = false;
        private static LogIn_Form? _instance;
        public static LogIn_Form Instance
        {
            get { return _instance == null ? new LogIn_Form() : _instance; }
        }
        private LogIn_Form()
        {
            InitializeComponent();
        }
        private async void LogInBtn_Click(object sender, EventArgs ev)
        {
            // avoid multiple invocation when clicking more than once
            // if is in process, wait for the proc to complete
            if (formIsInProc == true) return;
            formIsInProc = true; // else

            try
            {
                // validate username and password
                Task<User?> validateUser = UserHandler.Instance.ValidateUser(
                    username_TxtBox.Text, password_TxtBox.Text);

                // show a noti while processing, close when done
                NotiForm notiForm = new NotiForm();
                notiForm.Text = "Processing ...";
                notiForm.SetNotiLabelTxt("Validating username and password");

                notiForm.Show();
                User? user = await validateUser;
                notiForm.Hide();

                // display main menu if correspondingly to that valid user
                if (user != null)
                {
                    ViewOrder_Form form = new ViewOrder_Form(user);
                    MenuStripConsole.User = user;

                    Hide();
                    form.ShowDialog();
                    Show();
                }
                else MessageBox.Show("Wrong username or password");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            formIsInProc = false;
        }

        private void newUser_Btn_Click(object sender, EventArgs e)
        {

        }
    }
}