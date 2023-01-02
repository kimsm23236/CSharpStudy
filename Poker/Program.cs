using System;

namespace Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PokerGame PG = new PokerGame();
            PG.Init();
            while(true)
            {
                PG.Render();
                PG.Update();
            }
        }
    }
}