using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public bool isHit;
    }
    public struct ShipType
    {
        public string _shipType;
        public int _shipLength;
    }

    internal class Ship
    {
        public ShipType _type;
        public ShipPos[] _shipPos; // 0번 인덱스는 시작지점 위치
        public bool _shipError=false;
        public Ship()
        {
            _shipPos = new ShipPos[5];
            _type = new ShipType();
        }

        public void SetShipType(int index)//index는 함종류에 따른 번호 = 배의 칸수
        {
            _type._shipLength = index;
            switch (index)
            {
                case 1:
                    _type._shipType = "잠수함";
                   // Console.WriteLine("submarine");
                    break;
                case 2:
                    _type._shipType = "구축함";
                    //Console.WriteLine("goo");
                    break;
                case 3:
                    _type._shipType = "순양함";
                    //Console.WriteLine("soon");
                    break;
                case 4:
                    _type._shipType = "항공모함";
                    //Console.WriteLine("air");
                    break;
                case 5:
                    _type._shipType = "전함";
                    //Console.WriteLine("battle");
                    break;
                default:
                    break;
            }
            _shipPos = new ShipPos[_type._shipLength];



        }

        public bool isShipGetOut(int pointer)
        {
            Console.WriteLine(pointer);
            switch (pointer)
            {
                case 1://위
                    if (_shipPos[0]._shipY + _type._shipLength >= 10)
                    {
                        Console.WriteLine("배가 위로 벗어남");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case 2://아래
                    if (_shipPos[0]._shipY - _type._shipLength < 0)
                    {
                        Console.WriteLine("배가 아래로 벗어남");
                        return false;
                    }
                    else
                    {

                        return true;
                    }

                case 3://왼쪽
                    if (_shipPos[0]._shipX - _type._shipLength < 0)
                    {
                        Console.WriteLine("배가 왼쪽으로 벗어남");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                case 4://오른쪽
                    if (_shipPos[0]._shipX + _type._shipLength >= 10)
                    {
                        Console.WriteLine("배가 오른쪽으로 벗어남");
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                default:
                    Console.WriteLine(  "이상한거");
                    return false;
            }
        }

        public void ReadAndSetShip(ConsoleKeyInfo pressedKey)
        {
            //var pressedKey = Console.ReadKey();
            int shipFace = 0;
            //Console.WriteLine("readanssetship 돌입");
            //Console.WriteLine(pressedKey.Key);
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow: //키보드 위
                    shipFace = 1;
                    //Console.WriteLine("isshipgetout");
                    //Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        Console.WriteLine("isshipgetoutin");
                        for (int i = 1; i < _type._shipLength; i++)
                        {

                            /*디버그용
                            Console.WriteLine(_type._shipLength);
                            Console.WriteLine(_shipPos[0]._shipX);
                            Console.WriteLine(_shipPos[0]._shipY);*/
                            _shipPos[i]._shipX = _shipPos[0]._shipX;
                            //Console.WriteLine(_shipPos[i]._shipX);//디버그확인용
                            _shipPos[i]._shipY = _shipPos[i - 1]._shipY + 1;
                            _shipPos[i].isHit = false;
                            //Console.WriteLine(_shipPos[i]._shipY);//디버그 확인용


                        }
                        Console.WriteLine("위쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                        Console.WriteLine("errorU");
                    }
                    break;
                case ConsoleKey.DownArrow: //키보드 아래 
                    
                    shipFace = 2;
                    Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[0]._shipX;
                            _shipPos[i]._shipY = _shipPos[i - 1]._shipY - 1;
                            _shipPos[i].isHit = false;
                        }
                        Console.WriteLine("아래쪽으로 설정되었습니다");
                        _shipError = false;

                    }
                    else
                    {
                        _shipError = true;
                        Console.WriteLine("errorD");
                    }
                    break;
                case ConsoleKey.LeftArrow:  //키보드 왼쪽
                    shipFace = 3;
                    Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[i - 1]._shipX - 1;
                            _shipPos[i]._shipY = _shipPos[0]._shipY;
                            _shipPos[i].isHit = false;
                        }
                        Console.WriteLine("왼쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                        Console.WriteLine("errorL");
                    }
                    break;
                case ConsoleKey.RightArrow:  //키보드 오른쪽 
                    shipFace = 4;
                    Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[i - 1]._shipX + 1;
                            _shipPos[i]._shipY = _shipPos[0]._shipY;
                            _shipPos[i].isHit = false;
                        }
                        Console.WriteLine("오른쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                        Console.WriteLine("errorR");
                    }
                    break;
                default: //이외의 입력
                    Console.WriteLine("올바른 키가 아닙니다");
                    _shipError = true;
                    return;
                    //break;
            }


        }

        public void ReadAndSetShip(int pointer)
        {
            //var pressedKey = Console.ReadKey();
            int shipFace = 0;
            //Console.WriteLine("readanssetship 돌입");
            
            switch (pointer)
            {
                case 1: //키보드 위
                    shipFace = 1;
                    //Console.WriteLine("isshipgetout");
                    //Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                       // Console.WriteLine("isshipgetoutin");
                        for (int i = 1; i < _type._shipLength; i++)
                        {

                            /*디버그용
                            Console.WriteLine(_type._shipLength);
                            Console.WriteLine(_shipPos[0]._shipX);
                            Console.WriteLine(_shipPos[0]._shipY);*/
                            _shipPos[i]._shipX = _shipPos[0]._shipX;//1
                            //Console.WriteLine(_shipPos[i]._shipX);//디버그확인용
                            _shipPos[i]._shipY = _shipPos[i - 1]._shipY + 1;//3
                            //Console.WriteLine(_shipPos[i]._shipY);//디버그 확인용

                        }
                       // Console.WriteLine("위쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                       // Console.WriteLine("errorU");
                    }
                    break;
                case 2: //키보드 아래 

                    shipFace = 2;
                    //Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[0]._shipX;
                            _shipPos[i]._shipY = _shipPos[i - 1]._shipY - 1;
                        }
                        //Console.WriteLine("아래쪽으로 설정되었습니다");
                        _shipError = false;

                    }
                    else
                    {
                        _shipError = true;
                        //Console.WriteLine("errorD");
                    }
                    break;
                case 3:  //키보드 왼쪽
                    shipFace = 3;
                    //Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[i - 1]._shipX - 1;
                            _shipPos[i]._shipY = _shipPos[0]._shipY;
                        }
                       // Console.WriteLine("왼쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                        //Console.WriteLine("errorL");
                    }
                    break;
                case 4:  //키보드 오른쪽 
                    shipFace = 4;
                   // Console.WriteLine(shipFace);
                    if (isShipGetOut(shipFace))
                    {
                        for (int i = 1; i < _type._shipLength; i++)
                        {
                            _shipPos[i]._shipX = _shipPos[i - 1]._shipX + 1;
                            _shipPos[i]._shipY = _shipPos[0]._shipY;
                        }
                        //Console.WriteLine("오른쪽으로 설정되었습니다");
                        _shipError = false;
                    }
                    else
                    {
                        _shipError = true;
                        //Console.WriteLine("errorR");
                    }
                    break;
                default: //이외의 입력
                   // Console.WriteLine("올바른 키가 아닙니다");
                    _shipError = true;
                    return;
                    //break;
            }


        }
        public void IsSheepSink()
        {
            int hitCount = 0;
            int sinkShip = 0;
            for (int j=0;j< _type._shipLength; j++)
            {
                if (_shipPos[j].isHit)
                {
                    hitCount++;
                }
            }
            if(hitCount == _type._shipLength)
            {
                Console.WriteLine($"{_type._shipType}침몰!");
                sinkShip++;
            }
            if(sinkShip == 5)
            {
                Console.WriteLine("전멸했습니다!.");
                Game._gameOver = true;
            }

        }


    }//ship 마지막
}
