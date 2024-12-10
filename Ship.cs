using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15battleship
{
    /// <summary>
    /// 배의 길이는 1~5까지 배의 종류는 구축 순양 전함 항모 잠수함
    /// 구축=2, 순양=3 전함=4 항모=5 잠수함=1 로 설정
    /// 배의 정확한 위치는 ShipPos 구조체에 xy저장해서 배열로 가지고 있기
    /// 
    /// </summary>

    public struct ShipPos
    {
        public int _shipX;
        public int _shipY;
    }

    internal class Ship
    {
        
        public struct ShipType
        {
            public string _shipType;
            public int _shipLength;
        }
        public ShipPos[] _shipPos;
        





    }
}
