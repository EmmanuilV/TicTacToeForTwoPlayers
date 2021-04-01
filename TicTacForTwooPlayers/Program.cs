using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class Program
    {

        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse(args[0]);
                Int32 port = Int32.Parse(args[1]);

                server = new TcpListener(localAddr, port);

                server.Start();


                while (true)
                {
                    Console.Write("Waiting for a connection Player1 ");
                    TcpClient client1 = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");


                    Console.Write("Waiting for a connection Player2 ");
                    TcpClient client2 = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Game game = new Game();
                    Field field = new Field();
                    string[] positions = new string[9] { "", "", "", "", "", "", "", "", "" };
                    while (true)
                    {
                        NetworkStream stream1 = client1.GetStream();
                        NetworkStream stream2 = client2.GetStream();

                        Player player1 = new Player(positions, stream1);
                        Player player2 = new Player(positions, stream2);

                        player1.XO = "X";
                        player2.XO = "O";

                        if (player1.Checking == false || player2.Checking == false)
                        {
                            break;
                        }
                        else
                        {
                            player1.Play();
                            if (player1.Checking == false)
                            {
                                break;
                            }
                            else
                            {
                                player2.Play();
                            }

                        }
                    }

                    Console.WriteLine("Game Over!");
                    client1.Close();
                    client2.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

    }
}
