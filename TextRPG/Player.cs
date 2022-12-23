using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Status    // 스탯 클래스
    {
        
        public int Docs { get; set; }                   // 서류력
        public int Coding { get; set; }                 // 코딩력
        public int Algo { get; set; }                   // 알고력
        public int ag_BruteForce { get; set; }          // Brute Force
        public int ag_DP { get; set; }                  // DP
        public int ag_BDFS { get; set; }                // BFS DFS
        public int ag_Dijkstra { get; set; }            // Dijkstra
        public int ag_DivideAndConquer { get; set; }    // Divide and Conquer
        public int Interview { get; set; }              // 면접력

        public Status() 
        { 
            Docs = 0;
            Coding = 0;
            Algo = 0;
            ag_BruteForce = 0;
            ag_DP = 0;
            ag_BDFS = 0;
            ag_Dijkstra = 0;
            ag_DivideAndConquer = 0;
            Interview = 0;
        }
    }
    class Player
    {
        public string Name { get; set; }
        public Status Stat { get; set; }
        public Player()
        {
            Name = string.Empty;
            Stat = new Status();
        }

        public void InitPlayer()
        {
            // 타이틀 화면에서 엔터로 넘기면 이부분 넘어가는 이슈 있음//////////
            Console.Write("플레이어의 이름을 입력하세요 : ");        ///////
            Name = Console.ReadLine();                          ////////
            ////////////////////////////////////////////////////////////
            Thread.Sleep(1000);
            Console.WriteLine("플레이어의 초기 스탯을 설정합니다.");
            Thread.Sleep(1000);
            Console.WriteLine("서류력, 코딩력, 면접력을 각각 분배해주세요(전부 합쳐 10을 넘기면 안됩니다.)");
            int statPoint = 10;
            Thread.Sleep(500);
            bool bIsInitSucs = false;
            while (!bIsInitSucs) 
            {
                statPoint = 10;
                int docs = 0, coding = 0, itv = 0;
                Console.Write("서류력 : ");
                int.TryParse(Console.ReadLine(), out docs);
                Console.Write("코딩력 : ");
                int.TryParse(Console.ReadLine(), out coding);
                Console.Write("면접력 : ");
                int.TryParse(Console.ReadLine(), out itv);
                
                bIsInitSucs = docs + coding + itv <= 10;

                if (bIsInitSucs)
                {
                    Stat.Docs = docs;
                    Stat.Coding = coding;
                    Stat.Interview = itv;
                }
                else
                {
                    Console.WriteLine("[System Error] 초기 스탯 합이 10이 넘습니다. 다시 설정해주세요");
                }
            } // while
        }

        public void printCharacterProf()
        {
            Console.WriteLine("이름\t: {0}", Name);
            Console.WriteLine("서류력\t: {0}", Stat.Docs);
            Console.WriteLine("코딩력\t: {0}", Stat.Coding);
            Console.WriteLine("면접력\t: {0}", Stat.Interview);
        }

        public bool isFinishedInit()
        {
            bool bIsRightInfo = false;
            Console.WriteLine("설정하신 캐릭터의 정보가 제대로 입력 되었나요?");
            Console.Write("제대로 입력 되었다면 1, 아니라면 2 입력 : ");
            int num = 0;
            int.TryParse(Console.ReadLine(), out num);
            if(num == 1)
                bIsRightInfo = true;
            return bIsRightInfo;
        }
    }
}
