using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TextRPG
{
    public enum GameMode
    {
        None = 0,
        Title = 1,
        CreateCharacter = 2,
        MainGameLoop = 3,
        Combat = 4,
        Exit = 5,
    }
    class Game
    {
        private GameMode Mode = GameMode.Title;

        private CText titleText = new CText("취준생 이야기");

        private int consoleWidth;
        private int consoleHeight;
        private int CurrentWeek;

        private Player player;
        private Enemy[] JopPosts;
        public Enemy enemy;

        public Game()
        {
            // 임시 초기화
            consoleWidth = 100;
            consoleHeight = 30;
            Console.WindowWidth = consoleWidth;
            Console.WindowHeight= consoleHeight;
            titleText._position.x = 46;
            titleText._position.y = 15;

            player = new Player();
            JopPosts = new Enemy[5];
            for(int i = 0; i < 5; i++)
            {
                JopPosts[i] = new Enemy();
            }
            enemy = new Enemy();
            CurrentWeek = 1;
            // titleText._position.setVelocity(0, -1);
        }

        public void Process()
        {
            switch(Mode)
            {
                case GameMode.None:
                    break;
                case GameMode.Title:
                    Process_Title();
                    break;
                case GameMode.CreateCharacter:
                    Process_CreateCharacter();
                    break;
                case GameMode.MainGameLoop:
                    Process_MainGameLoop();
                    break; 
                case GameMode.Combat:
                    Process_Combat();
                    break;
                case GameMode.Exit:
                    break;
                default:
                    break;
            }
        }

        private void Process_Title()
        {  
            while(Console.KeyAvailable == false)
            {
                titleText.Update();
                titleText.Render();
                Thread.Sleep(200);
            }
            Mode = GameMode.CreateCharacter;
            Console.Clear();
        }

        private void Process_CreateCharacter()
        {
            bool isFinishCreateCharacter = false;
            while(!isFinishCreateCharacter)
            {
                Console.Clear();
                player.InitPlayer();
                player.printCharacterProf();
                isFinishCreateCharacter = player.isFinishedInit();
            }
            Mode = GameMode.MainGameLoop;
            
        }

        private void Process_MainGameLoop()
        {
            bool bIsStartCombat = false;
            bool bIsSuccessLoopEnd = false;
            int action = 0;
            while(!bIsStartCombat)
            {
                // 임시
                Console.Clear();
                Console.WriteLine("{0} 주차 입니다.", CurrentWeek);
                Console.WriteLine("당신이 할 수 있는 것에는 다음과 같은 것들이 있습니다.");
                Console.WriteLine("(1). 회사 지원\t(2) 미구현\t(3) 미구현\t(4) 미구현");
                int.TryParse(Console.ReadLine(), out action);
                switch(action)
                {
                    case 1:
                        Console.Clear();
                        int selectEnemy = 0;
                        Console.WriteLine("현재 지원할 수 있는 공고는 다음과 같습니다.");
                        for(int i = 0; i < JopPosts.Length; i++)
                        {
                            Console.WriteLine("{0}. {1}", i + 1, JopPosts[i].Name);
                        }
                        Console.WriteLine("뒤로 돌아가실려면 0을 입력하세요.");
                        int.TryParse(Console.ReadLine(), out selectEnemy);
                        if(selectEnemy == 0) // 뒤로 돌아가기
                        {
                            action = 0;
                        }
                        else if(selectEnemy > 0 && selectEnemy <= JopPosts.Length)
                        {
                            enemy = JopPosts[selectEnemy - 1];
                            Console.WriteLine("{0}로 결정하여 채용 과정에 들어갑니다.", enemy.Name);
                            bIsStartCombat = true;
                            Thread.Sleep(1000);
                            
                        }
                        else
                        {
                            Console.WriteLine("[System Error] 입력이 잘못되었습니다.");
                        }

                        break;
                    default: 
                        break;
                } // switch
                if(bIsStartCombat)
                {
                    Mode = GameMode.Combat;
                    bIsSuccessLoopEnd = true;
                }

                if(bIsSuccessLoopEnd)
                {
                    CurrentWeek++;
                }
            } // while
        }

        private void Process_Combat()
        {
            Console.WriteLine("전투 레벨 진입 확인");
            Mode = GameMode.MainGameLoop;
            Thread.Sleep(2000);
            
        }

    }
}
