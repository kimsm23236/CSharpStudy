﻿namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while(true)
            {
                game.Process();
            }
        }
    }
}