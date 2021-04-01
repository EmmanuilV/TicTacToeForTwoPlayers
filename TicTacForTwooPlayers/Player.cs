using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class Player
    {
        StreamReader reader;
        StreamWriter writer;
        private string[] positions;
        private NetworkStream stream;


        Game game = new Game();
        Field field = new Field();

        private string xo;
        private bool checking = true;

        public string XO
        {
            get
            {
                return XO;
            }
            set
            {
                if (value == "X")
                {
                    xo = "X";
                }
                else if (value == "O")
                {
                    xo = "O";
                }

            }
        }
        public bool Checking
        {
            get
            {
                return checking;
            }
        }

        public Player(string[] positions, NetworkStream stream)
        {
            this.positions = positions;
            this.stream = stream;
        }


        public void Play()
        {
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            writer.WriteLine(field.PlayField(positions));

            writer.WriteLine("Your turn! Enter the position number: ");
            int chooseCell = int.Parse(reader.ReadLine());

            if (checking)
            {

                if (chooseCell < 1 || chooseCell > 9)
                {
                    while (true)
                    {
                        writer.WriteLine("Enter number from 1 to 9");
                        chooseCell = int.Parse(reader.ReadLine());
                        if (chooseCell >= 1 && chooseCell <= 9)
                        {
                            Choose(positions, chooseCell);
                            //game.RenamePlayer();
                            break;
                        }
                    }
                }
                else
                {
                    Choose(positions, chooseCell);
                    //game.RenamePlayer();
                }
                //game.RenamePlayer();

                writer.WriteLine(field.PlayField(positions));
                // game.WinCheck(positions);
                writer.WriteLine(Status(positions));
            }
            else
            {
                stream.Close();
            }
        }
        private void Choose(string[] positions, int choose)
        {
            if (positions[choose - 1] == "")
            {
                positions[choose - 1] = xo;
            }
        }
        private string Status(string[] positions)
        {
            string status = "";
            if (game.WinCheck(positions) == "Win!")
            {
                status += $"{xo} Win!";
                checking = false;

            }
            else if (game.WinCheck(positions) == "Draw!!")
            {
                status += game.WinCheck(positions);
                checking = false;

            }
            else
            {
                status += game.WinCheck(positions);
            }
            return status;
        }


    }
}
