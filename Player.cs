using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15battleship
{
    internal class Player
    {
        public Ship[] _myShips;
        public GameField _myGameField;

        public Player()
        {
            _myShips = new Ship[5];//5개의 Ship이 들어간 배열
            _myGameField = new GameField();// 내 게임판 생성
        }

        public void SetPlayerShipToField(Player player)
        {

        }


    }
}
