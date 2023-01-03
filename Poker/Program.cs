using System;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 포커 게임 객체 생성 후
            PokerGame PG = new PokerGame();
            // 객체 초기화 함수
            PG.Init();
            // 게임 루프
            while(!PG.IsGameEnd)
            {
                // 게임 주요 로직, 내용 갱신 등으로 구성된 함수
                PG.Update();
                // 콘솔 출력 함수
                PG.Render();
            }
        }
    }
}