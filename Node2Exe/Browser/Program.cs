using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    static class Program
    {
        static void usage()
        {
            Console.WriteLine("Proper Usage is: Browser.exe url");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BrowserForm(args[0]));
            }
            else {
                usage();
            }
        }

    }
}
