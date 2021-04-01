/* using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Documents
{
    class NetGame
    {
        private string[] positions;

        Game game = new Game();
        Field field = new Field();

        public void Play(Player player1, Player player2)
        {
            while (game.Checking)
            {
                if (chooseCell < 1 || chooseCell > 9)
                {
                    while (true)
                    {
                        player1.Writer.WriteLine("Enter number from 0 to 8");
                        chooseCell = int.Parse(player1.Reader.ReadLine());
                        if (chooseCell >= 1 && chooseCell <= 9)
                        {
                            game.Choose(positions, chooseCell);
                            game.RenamePlayer();
                            break;
                        }
                    }
                }
                else
                {
                    game.Choose(positions, chooseCell);
                    game.RenamePlayer();
                }
                field.PlayField(positions);
                game.RenamePlayer();

                writer.WriteLine(field.PlayField(positions));
                writer.WriteLine(game.WinCheck(positions));

            }

        }


    }
}
 */