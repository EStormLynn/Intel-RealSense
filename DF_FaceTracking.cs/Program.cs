
using System;
using System.Windows.Forms;

namespace DF_FaceTracking.cs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            PXCMSession session = PXCMSession.CreateInstance();
            if (session != null)
            {
                Application.Run(new MainForm(session));
                session.Dispose();
            }
        }
    }
}
