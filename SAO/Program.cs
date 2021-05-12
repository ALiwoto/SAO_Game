using System;
using System.Windows.Forms;
using SAO.Controls.Music;

namespace SAO
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // set the unhandled exceptions handler in the game
            AppDomain.CurrentDomain.UnhandledException -= UnhandledExceptionChecker;
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionChecker;
            // load the entry checker of the game
            new LoadingService.EntryChecker().Run(args);
        }
        /// <summary>
        /// static Unhandled Exception checker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void UnhandledExceptionChecker(object sender, UnhandledExceptionEventArgs e)
        {
            // check if exception object is Exception or not
            if (e.ExceptionObject is Exception ex)
            {
                // pass the exception object as ex to the sound player
                // class to check if the source of the exception
                // is from woto audio player or not.
                if (SoundPlayer.IsOurFault(ex))
                {
                    // exit the enviroment immediately
                    Environment.Exit(1);
                }
            }
        }

    }
}
