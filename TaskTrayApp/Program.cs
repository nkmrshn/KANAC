using System;
using System.Threading;
using System.Windows.Forms;

namespace TaskTrayApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, Application.ProductName);

            if(!mutex.WaitOne(0, false))
            {
                return;
            }

            Application.Run(new MainForm());

            mutex.ReleaseMutex();
        }
    }
}
