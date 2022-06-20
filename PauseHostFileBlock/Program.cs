//Goal: Temporarily renames hostfile if run as admin. Is reset on app closure  or end of specified time.

string hostFileLocation = Environment.SystemDirectory + @"\drivers\etc\hosts";
string disabledFileLocation = Environment.SystemDirectory + @"\drivers\etc\hosts_Disabled";

try
{
    System.IO.FileInfo hostFile = new System.IO.FileInfo(hostFileLocation);
    if (hostFile.Exists)
    {
        hostFile.MoveTo(disabledFileLocation);
    }
}
catch (UnauthorizedAccessException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nSorry, you need admin privs to modify the host file");
    Console.ReadLine();
    Console.ResetColor();
}
