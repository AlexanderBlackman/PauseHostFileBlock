using System.Runtime.InteropServices;


namespace PauseHostFileBlock
{
    public class HostFileRenamer
    {
        public string hostFileLocation = Environment.SystemDirectory + @"\drivers\etc\hosts";
        public string disabledFileLocation = Environment.SystemDirectory + @"\drivers\etc\hosts_Disabled";
        public System.IO.FileInfo hostFile;

        public void ClassNamePlaceholder()
        {
            hostFile = new System.IO.FileInfo(hostFileLocation);

            if (hostFile.Exists)
            {
                hostFile.MoveTo(disabledFileLocation);
            }


            bool ConsoleEventCallback(int eventType)
            {
                if (eventType == 2)
                {
                    hostFile.MoveTo(hostFileLocation);
                }
                return false;
            }

            handler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(handler, true);
            Console.ReadLine();





        }


        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
                                               // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);


    }
}