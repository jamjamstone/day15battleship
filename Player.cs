using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15battleship
{
   
    internal class Player
    {
        public Ship[] _Ships;
        public GameField _GameField;
        public bool _error=true;
        Random random = new Random();
        public Player()
        {
            _Ships = new Ship[5];//5개의 Ship이 들어간 배열
            for (int i = 0; i < 5; i++) 
            {
                _Ships[i] = new Ship();
            }
            _Ships[0].SetShipType(5);//0번 배는 전함
            _Ships[1].SetShipType(4);//1번배는 항모
            _Ships[2].SetShipType(3);//2번배는 순양
            _Ships[3].SetShipType(2);//3번배는 구축
            _Ships[4].SetShipType(1);//4번 배는 잠수함
            _GameField = new GameField();// 내 게임판 생성
        }

        public void SetPlayerShipToField(GameField gameField, Ship ship)
        {
            if (isShipSeperate(gameField,ship) == true)
            {

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        for (int k = 0; k < ship._type._shipLength; k++)
                        {
                            if (i == ship._shipPos[k]._shipY && j == ship._shipPos[k]._shipX)
                            {
                                gameField._gameField[i, j] = 1;
                                Console.WriteLine("배의 일부분 할당");
                            }
                        }
                    }
                }
                _error = false;
            }
            else
            {
                Console.WriteLine("error");
                _error = true;//에러가 발생할때
            }
        }
        public bool isShipSeperate(GameField gameField, Ship ship)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < ship._type._shipLength; k++)
                    {
                        if (i == ship._shipPos[k]._shipY && j == ship._shipPos[k]._shipX)
                        {
                            if(gameField._gameField[i, j] == 1)
                            {
                                Console.WriteLine("배가 겹침");
                                return false;// 배가 겹쳐있다.
                            }
                        }
                    }
                }
            }
            Console.WriteLine("배가 분리되어있음");
            return true;//배가 분리되어 있다.
        }

        public void RandomShipSet()
        {

            random.Next(0, 5);
        }

    }
}
