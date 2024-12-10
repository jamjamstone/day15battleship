using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15battleship
{
    internal class GameField
    {
        public int[,] _gameField;

        public GameField()
        {
            _gameField = new int[10, 10];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    _gameField[i, j] = 0;
                }
            }
        }
        public void GameFieldCheck(Player player )
        {


        }
        public void DrawGameField(Player player)
        {

        }


    }
}
