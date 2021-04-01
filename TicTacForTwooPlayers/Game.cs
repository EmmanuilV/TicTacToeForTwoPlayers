using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class Game
    {
        private const string O = "O";
        private const string X = "X";
        private string xo;
//        private bool checking = true;
        private Player player;
        //private string[] positions = new string[9] { "", "", "", "", "", "", "", "", "" };


/*         public bool Checking
        {
            get
            {
                return checking;
            }
        } */


            
/*         public string[] Positions
        {
            get
            {
                return positions;
            }
        } */
        public string WinCheck(string[] positions)
        {
            string status = "";

            if (positions[0] == positions[1] && positions[0] == positions[2] && positions[0] != "")
            {
                status += "Win!";
            }
            else if (positions[0] == positions[4] && positions[0] == positions[8] && positions[0] != "")
            {
                status += "Win!";
            }
            else if (positions[0] == positions[3] && positions[0] == positions[6] && positions[0] != "")
            {
                status += "Win!";
            }
            else if (positions[8] == positions[7] && positions[8] == positions[6] && positions[8] != "")
            {
                status += "Win!";
            }
            else if (positions[2] == positions[4] && positions[2] == positions[6] && positions[2] != "")
            {
                status += "Win!";
            }
            else if (positions[1] == positions[4] && positions[1] == positions[7] && positions[1] != "")
            {
                status += "Win!";
            }
            else if (positions[3] == positions[4] && positions[3] == positions[5] && positions[3] != "")
            {
                status += "Win!";
            }
            else if (positions.Length == 9)
            {
                int sum = 0;
                for (int i = 0; i < positions.Length; i++)
                {
                    if (positions[i] == "")
                    {
                        sum += 1;
                    }
                    else
                    {
                        continue;
                    }

                }
                if (sum == 0)
                {
                    status = "Draw!!";
                    
                }
                else
                {
                    status = "The game continues!\nNow is opponent's turn!\n";
                }
            }
            else
            {
                status = "The game continues!\nNow is opponent's turn!\n";
            }

            return status;
        }
/*         public void RenamePlayer()
        {
            if (xo == X)
            {
                xo = O;
            }
            else
            {
                xo = X;
            }
        } */

    }
}