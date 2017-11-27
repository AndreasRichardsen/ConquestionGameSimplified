using ConquestionGame.PresentationLayer.SimpleWinForm.ConquestionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquestionGame.PresentationLayer.SimpleWinForm
{
    static class Program
    {
        public static ConquestionServiceClient client { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            client = new ConquestionServiceClient();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
}
