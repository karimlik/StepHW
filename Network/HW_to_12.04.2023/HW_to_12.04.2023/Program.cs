//UDP

/*using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace RPSGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up server
            UdpClient server = new UdpClient(8080);
            IPEndPoint remoteEP1 = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint remoteEP2 = new IPEndPoint(IPAddress.Any, 0);

            int numRounds = 3;
            int player1Score = 0;
            int player2Score = 0;
            string winner = "";
            for (int i = 1; i <= numRounds; i++)
            {
                Console.WriteLine("Round " + i);
                // receive message from client 1
                byte[] receiveBytes1 = server.Receive(ref remoteEP1);
                string receiveString1 = Encoding.ASCII.GetString(receiveBytes1);
                Console.WriteLine("Player 1's choice: " + receiveString1);

                // receive message from client 2
                byte[] receiveBytes2 = server.Receive(ref remoteEP2);
                string receiveString2 = Encoding.ASCII.GetString(receiveBytes2);
                Console.WriteLine("Player 2's choice: " + receiveString2);

                // determine winner and send message back to clients
                if (receiveString1 == receiveString2)
                    winner = "Tie";
                else if ((receiveString1 == "rock" && receiveString2 == "scissors") ||
                         (receiveString1 == "paper" && receiveString2 == "rock") ||
                         (receiveString1 == "scissors" && receiveString2 == "paper"))
                {
                    winner = "Player 1";
                    player1Score++;
                }
                    
                else
                {
                    winner = "Player 2";
                    player2Score++;
                }
            }

            if(player1Score > player2Score)
            {
                winner = "Player 1";
            }
            else if (player1Score < player2Score)
            {
                winner = "Player 2";
            }
            else
            {
                winner = "Tie";
            }

            winner = "Winner: " + winner;
            SendMessage(winner, server, remoteEP1, remoteEP2);
        }

        private static void SendMessage(string message, UdpClient server, IPEndPoint remoteEP1, IPEndPoint remoteEP2)
        {
            byte[] sendBytes1 = Encoding.ASCII.GetBytes(message);
            server.Send(sendBytes1, sendBytes1.Length, remoteEP1);
            byte[] sendBytes2 = Encoding.ASCII.GetBytes(message);
            server.Send(sendBytes2, sendBytes2.Length, remoteEP2);
        }
    }
}
*/


//TCP 

using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace RPSGameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up server
            TcpListener server = new TcpListener(IPAddress.Any, 8080);
            server.Start();

            int numRounds = 3;
            int player1Score = 0;
            int player2Score = 0;
            string winner = "";

            Console.WriteLine("Waiting for players to connect...");

            // wait for player 1 to connect
            TcpClient player1 = server.AcceptTcpClient();
            Console.WriteLine("Player 1 connected");

            // wait for player 2 to connect
            TcpClient player2 = server.AcceptTcpClient();
            Console.WriteLine("Player 2 connected");

            for (int i = 1; i <= numRounds; i++)
            {
                Console.WriteLine("Round " + i);

                // receive message from player 1
                byte[] receiveBytes1 = new byte[1024];
                int numBytes1 = player1.GetStream().Read(receiveBytes1, 0, receiveBytes1.Length);
                string receiveString1 = Encoding.ASCII.GetString(receiveBytes1, 0, numBytes1);
                Console.WriteLine("Player 1's choice: " + receiveString1);

                // receive message from player 2
                byte[] receiveBytes2 = new byte[1024];
                int numBytes2 = player2.GetStream().Read(receiveBytes2, 0, receiveBytes2.Length);
                string receiveString2 = Encoding.ASCII.GetString(receiveBytes2, 0, numBytes2);
                Console.WriteLine("Player 2's choice: " + receiveString2);

                // determine winner and send message back to players
                if (receiveString1 == receiveString2)
                    winner = "Tie";
                else if ((receiveString1 == "rock" && receiveString2 == "scissors") ||
                         (receiveString1 == "paper" && receiveString2 == "rock") ||
                         (receiveString1 == "scissors" && receiveString2 == "paper"))
                {
                    winner = "Player 1";
                    player1Score++;
                }

                else
                {
                    winner = "Player 2";
                    player2Score++;
                }
            }

            // determine final winner
            if (player1Score > player2Score)
            {
                winner = "Player 1";
            }
            else if (player1Score < player2Score)
            {
                winner = "Player 2";
            }
            else
            {
                winner = "Tie";
            }

            SendMessage(player1, player2, $"Final winner is {winner}");
        }

        private static void SendMessage(TcpClient player1, TcpClient player2, string message)
        {
            byte[] sendBytes1 = Encoding.ASCII.GetBytes(message);
            player1.GetStream().Write(sendBytes1, 0, sendBytes1.Length);
            byte[] sendBytes2 = Encoding.ASCII.GetBytes(message);
            player2.GetStream().Write(sendBytes2, 0, sendBytes2.Length);
        }
    }
}