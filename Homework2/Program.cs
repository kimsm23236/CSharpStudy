using System;

namespace Homework
{
    public class Program
    {
        static void Main()
        { 
            // 게임 객체 생성
            Game game = Game.Instance;
            // 게임 객체 초기화
            game.Init();
            // 키 입력을 받기 위한 ConsoleKeyInfo 구조체 
            // ConsoleKeyInfo cki;
            game.Start();
            // game.OnSpawnTimer();
            
        }
    }
}
