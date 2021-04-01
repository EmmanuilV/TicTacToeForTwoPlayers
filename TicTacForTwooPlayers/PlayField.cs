using System;

namespace Documents
{
    class Field
    {
        Game game = new Game();
        public string PlayField(string[] positions)//public string PlayField()
        {
            return $"   {positions[0]} |  {positions[1]}  |  {positions[2]}   \n" +
            "--------------\n" +
            $"   {positions[3]} |  {positions[4]}  |  {positions[5]}   \n" +
            "--------------\n" +
            $"   {positions[6]} |  {positions[7]}  |  {positions[8]}   \n";
        }
/*         public string PlayField()
        {
            return $"   {game.Positions[0]} |  {game.Positions[1]}  |  {game.Positions[2]}   \n" +
            "--------------\n" +
            $"   {game.Positions[3]} |  {game.Positions[4]}  |  {game.Positions[5]}   \n" +
            "--------------\n" +
            $"   {game.Positions[6]} |  {game.Positions[7]}  |  {game.Positions[8]}   \n";
        } */
    }
}