//UDP

/*using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RPSGameClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up client
            UdpClient client = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            // ask user whether they want to play with a human or the computer
            Console.Write("Do you want to play with a human or the computer? ");
            string opponent = Console.ReadLine().ToLower();
            while (opponent != "human" && opponent != "computer")
            {
                Console.Write("Invalid choice. Please choose human or computer: ");
                opponent = Console.ReadLine().ToLower();
            }

            string choice = "";
            for (int i = 0; i < 3; i++)
            {
                // get user's choice
                if (opponent == "human")
                {
                    Console.Write("Your choice (rock, paper, scissors): ");
                    choice = Console.ReadLine().ToLower();
                    while (choice != "rock" && choice != "paper" && choice != "scissors")
                    {
                        Console.Write("Invalid choice. Please choose rock, paper, or scissors: ");
                        choice = Console.ReadLine().ToLower();
                    }
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, 4);
                    if (randomNumber == 1)
                        choice = "rock";
                    else if (randomNumber == 2)
                        choice = "paper";
                    else
                        choice = "scissors";
                    Console.WriteLine("Computer's choice: " + choice);
                }

                // send user's choice to server
                byte[] sendBytes = Encoding.ASCII.GetBytes(choice);
                client.Send(sendBytes, sendBytes.Length, serverEP);

                Console.WriteLine($"Round {i + 1}");
            }
            // receive message from server
            byte[] receiveBytes = client.Receive(ref serverEP);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);
            Console.WriteLine(receiveString);

            client.Close();
        }
    }
}
*/


//TCP

//UDP

/*using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RPSGameClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up client
            UdpClient client = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            // ask user whether they want to play with a human or the computer
            Console.Write("Do you want to play with a human or the computer? ");
            string opponent = Console.ReadLine().ToLower();
            while (opponent != "human" && opponent != "computer")
            {
                Console.Write("Invalid choice. Please choose human or computer: ");
                opponent = Console.ReadLine().ToLower();
            }

            for (int i = 0; i < 3; i++)
            {
                // get user's choice
                string choice = "";
                if (opponent == "human")
                {
                    Console.Write("Your choice (rock, paper, scissors): ");
                    choice = Console.ReadLine().ToLower();
                    while (choice != "rock" && choice != "paper" && choice != "scissors")
                    {
                        Console.Write("Invalid choice. Please choose rock, paper, or scissors: ");
                        choice = Console.ReadLine().ToLower();
                    }
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, 4);
                    if (randomNumber == 1)
                        choice = "rock";
                    else if (randomNumber == 2)
                        choice = "paper";
                    else
                        choice = "scissors";
                    Console.WriteLine("Computer's choice: " + choice);
                }
                // send user's choice to server
                byte[] sendBytes = Encoding.ASCII.GetBytes(choice);
                client.Send(sendBytes, sendBytes.Length, serverEP);
                Console.WriteLine($"Round {i + 1}");


            }
            // receive message from server
            byte[] receiveBytes = client.Receive(ref serverEP);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);
            Console.WriteLine(receiveString);
            

            client.Close();
        }
    }
}*/


//TCP

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RPSGameClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up client
            TcpClient client = new TcpClient();
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            int serverPort = 8080;

            // connect to server
            client.Connect(serverIP, serverPort);

            // ask user whether they want to play with a human or the computer
            Console.Write("Do you want to play with a human or the computer? ");
            string opponent = Console.ReadLine().ToLower();
            while (opponent != "human" && opponent != "computer")
            {
                Console.Write("Invalid choice. Please choose human or computer: ");
                opponent = Console.ReadLine().ToLower();
            }

            for (int i = 0; i < 3; i++)
            {
                // get user's choice
                string choice = "";
                if (opponent == "human")
                {
                    Console.Write("Your choice (rock, paper, scissors): ");
                    choice = Console.ReadLine().ToLower();
                    while (choice != "rock" && choice != "paper" && choice != "scissors")
                    {
                        Console.Write("Invalid choice. Please choose rock, paper, or scissors: ");
                        choice = Console.ReadLine().ToLower();
                    }
                }
                else
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, 4);
                    if (randomNumber == 1)
                        choice = "rock";
                    else if (randomNumber == 2)
                        choice = "paper";
                    else
                        choice = "scissors";
                    Console.WriteLine("Computer's choice: " + choice);
                }

                // send user's choice to server
                NetworkStream stream = client.GetStream();
                byte[] sendBytes = Encoding.ASCII.GetBytes(choice);
                stream.Write(sendBytes, 0, sendBytes.Length);
                Console.WriteLine($"Round {i + 1}");

            }

            // receive message from server
            byte[] finalBytes = new byte[1024];
            NetworkStream finalStream = client.GetStream();
            finalStream.Read(finalBytes, 0, finalBytes.Length);
            string finalString = Encoding.ASCII.GetString(finalBytes);
            Console.WriteLine(finalString);

            client.Close();
        }
    }
}

