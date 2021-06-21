using System;
using System.Windows.Forms;

namespace MemoryClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try 
            { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginScreen());
            }
            catch(Exception e)
            { MessageBox.Show("Something went wrong"); }
        }
    }
}
