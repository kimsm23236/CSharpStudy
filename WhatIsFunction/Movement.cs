using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatIsFunction
{
    enum DIRECTION
    {
        NONE = 0,
        RIGHT, DOWN, LEFT, UP
    }

    public class Player
    {
        public int curX { get; set; }
        public int curY { get; set; }
        public char arrow { get; set; }
        private DIRECTION curDirection { get; set; }

        public Player() 
        {
            curX = 1;
            curY = 1;
            curDirection = DIRECTION.RIGHT;
            arrow = '▶';
        }

        bool isBlocked(char[,] m, int nx, int ny)
        {
            bool bIsBlocked = false;

            if (m[ny,nx] == '■')
                bIsBlocked = true;

            return bIsBlocked;
        }

        public void move(char[,] m)
        {
            int nextX = 0, nextY = 0;
            switch(curDirection)
            {
                case DIRECTION.LEFT:
                    nextX = curX - 1;
                    nextY = curY;
                    break;
                case DIRECTION.RIGHT:
                    nextX = curX + 1;
                    nextY = curY;
                    break;
                case DIRECTION.DOWN:
                    nextX = curX;
                    nextY = curY + 1;
                    break;
                case DIRECTION.UP:
                    nextX = curX;
                    nextY = curY - 1;
                    break;
                default:
                    break;
            }
            if(!isBlocked(m, nextX, nextY))
            {
                curX= nextX;
                curY= nextY;
            }
        }
        public void Update(char[,] m, ConsoleKeyInfo ki)
        {
            switch(ki.Key)
            {
                case ConsoleKey.W:
                    curDirection = DIRECTION.UP;
                    arrow = '▲';
                    break;
                case ConsoleKey.A:
                    curDirection = DIRECTION.LEFT;
                    arrow = '◀';
                    break;
                case ConsoleKey.S:
                    curDirection = DIRECTION.DOWN;
                    arrow = '▼';
                    break;
                case ConsoleKey.D:
                    curDirection = DIRECTION.RIGHT;
                    arrow = '▶';
                    break;
                default:
                    return;
            }
            move(m);
        }
        public void Render()
        {
            // Console.SetCursorPosition(curX, curY);
            switch(curDirection)
            {
                case DIRECTION.LEFT:
                    Console.Write("◀");
                    break;
                case DIRECTION.RIGHT:
                    Console.Write("▶");
                    break;
                case DIRECTION.DOWN:
                    Console.Write("▼");
                    break;
                case DIRECTION.UP:
                    Console.Write("▲");
                    break;
                default:
                    break;
            }
        }
    }

    public class Game
    {
        char[,] map = new char[100, 100];

        public Player player = new Player();

        public const int width = 20;
        public const int height = 20;
        public void Init()
        {
            for(int i = 0; i <= map.GetUpperBound(0); i++)
            {
                for(int j = 0; j < map.GetUpperBound(1); j++)
                {
                    map[i, j] = ' ';
                }
            }

            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    if(i == 0 || j == 0)
                        map[i, j] = '■';
                    if(i == height || j == width)
                        map[i, j] = '■';
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    if (i == player.curY && j == player.curX)
                    {
                        Console.Write("{0}", player.arrow);
                    }
                    else if (map[i,j] != '■')
                        Console.Write("{0,2}", map[i, j]);
                    else
                        Console.Write("{0}", map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Update(ConsoleKeyInfo cki)
        {
            player.Update(map, cki);
        }

    }

    
    public class Movement
    {
        static void Main()
        { 
            Game game = new Game();
            game.Init();
            ConsoleKeyInfo cki;
            while(true)
            {
                game.Render();
                cki = Console.ReadKey();
                game.Update(cki);
            }
            
        }
    }
}
