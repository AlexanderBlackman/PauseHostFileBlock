using PauseHostFileBlock;
//Goal: Temporarily renames hostfile if run as admin. Is reset on app closure  or end of specified time.

try
{

    var hostFileRenamer = new HostFileRenamer();
    Console.ReadLine();


}
catch (UnauthorizedAccessException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nSorry, you need admin privs to modify the host file");
    Console.ReadLine();
    Console.ResetColor();
}
