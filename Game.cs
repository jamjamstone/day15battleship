using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace day15battleship
{
    
    internal class Game
    {
        public static bool _gameOver = false;
        Random random = new Random();
        public bool isKeyRight(ConsoleKeyInfo key)
        {
            if (key.Key != ConsoleKey.DownArrow)
            {
                return true;
            }
            else if (key.Key != ConsoleKey.UpArrow)
            {
                return true;
            }
            else if (key.Key != ConsoleKey.LeftArrow)
            {
                return true;
            }
            else if (key.Key != ConsoleKey.RightArrow)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Player _player;
        public Player _enemy;

        public Game()
        {
            _enemy = new Player();
            _player = new Player();
        }

        public void Play()
        {
            Console.WriteLine("게임 시작! 엔터를 누르세요");
            var pressedKey = Console.ReadKey();

            bool settingShipSwitch = true;
            while (_player._error)
            {
                Console.WriteLine("5칸짜리 전함을 설치할 좌표를 선택해 주십시오");//에러 조건 최초로 에러나게 할당 할 때
                Console.WriteLine("선수의 x좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[0]._shipPos[0]._shipX);
                Console.WriteLine("선수의 y좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[0]._shipPos[0]._shipY);
                Console.WriteLine("전함의 방향을 선택해 주십시오");
                _player._Ships[0]._shipPos[0].isHit = false;
                settingShipSwitch = true;
                pressedKey = Console.ReadKey();
                while (settingShipSwitch)
                {
                    if (Console.KeyAvailable)
                    {
                        //Console.WriteLine("start");//디버그용 
                        if (isKeyRight(pressedKey))
                        {
                            pressedKey = Console.ReadKey();
                            _player._Ships[0].ReadAndSetShip(pressedKey);// 할당 실패해도 넘어감 다시 할당받게 해야함=> 해결
                            if (!_player._Ships[0]._shipError)
                            {
                                settingShipSwitch = false;
                            }
                            else
                            {
                                Console.WriteLine("전함의 방향을 선택해 주십시오");
                            }
                            
                        }
                    }
                }
                _player.SetPlayerShipToField(_player._GameField, _player._Ships[0]);
            }
            _player._error = true;
            while (_player._error)
            {
                Console.WriteLine("4칸짜리 항공모함을 설치할 좌표를 선택해 주십시오");
                Console.WriteLine("선수의 x좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[1]._shipPos[0]._shipX);
                Console.WriteLine("선수의 y좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[1]._shipPos[0]._shipY);
                Console.WriteLine("항공모함의 방향을 선택해 주십시오");
                _player._Ships[1]._shipPos[0].isHit = false;
                settingShipSwitch = true;
                pressedKey = Console.ReadKey();
                while (settingShipSwitch)
                {
                    if (Console.KeyAvailable)
                    {
                        //Console.WriteLine("start");//디버그용 
                        

                        if (isKeyRight(pressedKey))
                        {
                            Console.WriteLine("work");
                            pressedKey = Console.ReadKey();
                            _player._Ships[1].ReadAndSetShip(pressedKey);
                            if (!_player._Ships[1]._shipError)
                            {
                                settingShipSwitch = false;
                            }
                            else
                            {
                                Console.WriteLine("항공모함의 방향을 선택해 주십시오");
                            }
                        }
                        
                        
                    }
                }
                _player.SetPlayerShipToField(_player._GameField, _player._Ships[1]);
            }
            _player._error = true;
            while (_player._error)
            {
                Console.WriteLine("3칸짜리 순양함을 설치할 좌표를 선택해 주십시오");
                Console.WriteLine("선수의 x좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[2]._shipPos[0]._shipX);
                Console.WriteLine("선수의 y좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[2]._shipPos[0]._shipY);
                Console.WriteLine("순양함의 방향을 선택해 주십시오");
                _player._Ships[2]._shipPos[0].isHit = false;
                settingShipSwitch = true;
                pressedKey = Console.ReadKey();
                while (settingShipSwitch)
                {
                    if (Console.KeyAvailable)
                    {
                        //Console.WriteLine("start");//디버그용 
                        if (isKeyRight(pressedKey))
                        {
                            pressedKey = Console.ReadKey();
                            _player._Ships[2].ReadAndSetShip(pressedKey);
                            if (!_player._Ships[2]._shipError)
                            {
                                settingShipSwitch = false;
                            }
                            else
                            {
                                Console.WriteLine("순양함의 방향을 선택해 주십시오");
                            }
                        }
                    }
                }
                _player.SetPlayerShipToField(_player._GameField, _player._Ships[2]);
            }
            _player._error = true;
            while (_player._error)
            {
                Console.WriteLine("2칸짜리 구축함을 설치할 좌표를 선택해 주십시오");
                Console.WriteLine("선수의 x좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[3]._shipPos[0]._shipX);
                Console.WriteLine("선수의 y좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[3]._shipPos[0]._shipY);
                _player._Ships[3]._shipPos[0].isHit = false;
                Console.WriteLine("구축함의 방향을 선택해 주십시오");
                settingShipSwitch = true;
                pressedKey = Console.ReadKey();
                while (settingShipSwitch)
                {
                    if (Console.KeyAvailable)
                    {
                        //Console.WriteLine("start");//디버그용 
                        if (isKeyRight(pressedKey))
                        {
                            pressedKey = Console.ReadKey();
                            _player._Ships[3].ReadAndSetShip(pressedKey);
                            if (!_player._Ships[3]._shipError)
                            {
                                settingShipSwitch = false;
                            }
                            else
                            {
                                Console.WriteLine("구축함의 방향을 선택해 주십시오");
                            }
                        }
                    }
                }
                _player.SetPlayerShipToField(_player._GameField, _player._Ships[3]);
            }
            _player._error = true;
            while (_player._error)
            {
                Console.WriteLine("1칸짜리 잠수함을 설치할 좌표를 선택해 주십시오");
                Console.WriteLine("선수의 x좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[4]._shipPos[0]._shipX);
                Console.WriteLine("선수의 y좌표");
                int.TryParse(Console.ReadLine(), out _player._Ships[4]._shipPos[0]._shipY);
                _player._Ships[4]._shipPos[0].isHit = false;
                Console.WriteLine("잠수함의 방향을 선택해 주십시오");
                settingShipSwitch = true;
                pressedKey = Console.ReadKey();
                while (settingShipSwitch)
                {
                    if (Console.KeyAvailable)
                    {
                        //Console.WriteLine("start");//디버그용 
                        if (isKeyRight(pressedKey))
                        {
                            pressedKey = Console.ReadKey();
                            _player._Ships[4].ReadAndSetShip(pressedKey);
                            if (!_player._Ships[4]._shipError)
                            {
                                settingShipSwitch = false;
                            }
                            else
                            {
                                Console.WriteLine("잠수함의 방향을 선택해 주십시오");
                            }
                        }
                    }
                }//여기까지 진행시 1~5번까지의 모든 배의 좌표가 설정된다.//배가 겹쳐있을 경우 생각 안되있음 =>해결, 위 기능 가능하면 메소드로 만들어 보자
                _player.SetPlayerShipToField(_player._GameField, _player._Ships[4]);
            }
            _enemy.RandomShipSet();
            Console.WriteLine("게임준비 완료! 엔터를 눌러주세요!");
            Console.ReadKey();
            bool isMyTurn = true;
            int atkX;
            int atkY;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            
            while (!_gameOver)
            {
                _player._GameField.DrawGameField();//게임판 그림
                if (isMyTurn) 
                {
                    Console.WriteLine("공격할 x좌표를 입력하십시오");
                    int.TryParse(Console.ReadLine(), out atkX);
                    Console.WriteLine("공격할 y좌표를 입력하십시오");
                    int.TryParse(Console.ReadLine(), out atkY);
                    timer.Restart();
                    while (timer.ElapsedMilliseconds<500)
                    {

                    }
                    if(_enemy.isHit(atkX, atkY))
                    {
                        Console.WriteLine("맞췄습니다!");
                    }
                    _enemy.Attack(atkX,atkY,_enemy);//적에게 atkx,atky좌표 공격
                    isMyTurn = false;
                    _player._GameField.DrawGameField();
                }
                else
                {
                    timer.Restart();
                    while (timer.ElapsedMilliseconds < 500)
                    {

                    }
                    Console.WriteLine("적팀의 공격");
                    atkX = random.Next(0, 9);
                    atkY = random.Next(0,9);
                    _player.Attack(atkX, atkY, _player);
                    if (_player.isHit(atkX, atkY)) 
                    {
                        Console.WriteLine("공격당했습니다!");
                    }
                    isMyTurn=true;
                }



            }
                


            /// 컴퓨터가 무작위로 배의 위치를 설정하는 기능// 어느정도 구현
            /// 플레이어와 컴퓨터가 번갈아 가면서 플레이 하는 기능
            ///  맞았을 때 침몰이면 침몰표시=>구현 완료 테스트 필요, 게임판 그리기=>테스트중










        }//play의 끝









    }
}
