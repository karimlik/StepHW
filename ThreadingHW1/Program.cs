using System;
using System.Threading;
using System.Diagnostics;


Console.WriteLine("Press Y to lauch child process, N to close app: ");

var keyPressed = Console.ReadKey().Key;

if (keyPressed == ConsoleKey.Y)
{
    Console.WriteLine("\bInput file location: ");
    string? fileLoc = Console.ReadLine();

    if (fileLoc != null)
    {
        try
        {
            var task = Process.Start(fileLoc);
            task.Start();

            Console.WriteLine("\bChoose what to do:\nPress A for \'Wait for Exit\'\nPress D for \'Force Quit app\': ");
            var choiceKey = Console.ReadKey().Key;

            if (choiceKey == ConsoleKey.A)
            {
                task.WaitForExit();
                var exitCode = task.ExitCode;
                Console.WriteLine(exitCode);
            }
            else if (choiceKey == ConsoleKey.D)
            {
                task.Kill();
                Console.WriteLine("\bTask Force Closed!");
                return;
            }

        }
        catch
        {
            Console.WriteLine("Something went bad");
        }
    }
    else
    {
        return;
    }
}
else
{
    Console.WriteLine("\bClosing app...");
    return;
}