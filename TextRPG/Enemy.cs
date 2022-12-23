using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum EALGORITHM
    {
        NONE = 0,
        Bruteforce = 1,
        DP = 2,
        BDFS = 3,
        Dijkstra = 4,
        DivideAndConquer = 5,
    }

    class CodingTest // 코딩 테스트
    {
        public int LEVEL { get; set; }

        public EALGORITHM eAlgorithm;

        public CodingTest()
        {
            Random rd = new Random();
            int rdNum = rd.Next(1, 5 + 1);
            switch(rdNum)
            {
                case 1:
                    eAlgorithm = EALGORITHM.Bruteforce;
                    break;
                case 2:
                    eAlgorithm = EALGORITHM.DP;
                    break;
                case 3:
                    eAlgorithm = EALGORITHM.BDFS;
                    break;
                case 4:
                    eAlgorithm = EALGORITHM.Dijkstra;
                    break;
                case 5:
                    eAlgorithm = EALGORITHM.DivideAndConquer;
                    break;
                default:
                    break;
            }
            
        }
    }
    class EnemyStatus
    {
        public int HP;
        public int ATK;
        public EnemyStatus()
        {
            HP = 100;
            ATK = 10;
        }
    }
    class Enemy
    {
        public string Name { get; set; }
        public EnemyStatus Stat { get; set; }
        public CodingTest[] CoTest;

        public Enemy() 
        {
            // 임시 초기화
            Name = "넥슨 공채";
            Stat = new EnemyStatus();
            CoTest = new CodingTest[4];
        }
    }
}
