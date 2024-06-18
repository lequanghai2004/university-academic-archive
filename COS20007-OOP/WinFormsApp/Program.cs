using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;
using System.Text;
using System.Security.Cryptography;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            try
            {  
                ApplicationConfiguration.Initialize();
                //Application.Run(LogIn_Form.Instance);

                // for testing
                //LogIn_Form logInF = LogIn_Form.Instance;
                //NotiForm notiF = new NotiForm();
                ViewOrder_Form uTF = new ViewOrder_Form(new User(1,100));
                HandleAccount_Form cuf = new HandleAccount_Form(true);
                NewOrder_Form nod = new NewOrder_Form();
                Demo_Form demo = new Demo_Form();
                //notiF.SetNotiLabelTxt("aaaaaaaaaaadd");

                Application.Run(uTF);
            }
            catch (Exception e)
            {
                MessageBox.Show("Initialize application failed: " + e.Message);
            }
        }
    }
}