using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsClass
{
    public class DrawAndBet
    {
        public DrawAndBet() 
        {
            playerPoint = 10000;
            trumpCard = new TrumpCard();
        }
        public int playerPoint { get; set; }
        public TrumpCard trumpCard { get; set; }

        public void Start()
        {
            GameLoop();
        }
        private void GameLoop()
        {
            while(true)
            {
                int CCard1, CCard2, PCard;
                // { 컴퓨터의 카드 2장 출력
                CCard1 = trumpCard.ReRollCard();
                CCard2 = trumpCard.ReRollCard();
                // } 컴퓨터의 카드 2장 출력

                int betPoint = 0;
                // { 플레이어 베팅 입력
                betPoint = Bet();
                playerPoint -= betPoint;
                // } 플레이어 베팅 입력

                // { 플레이어 카드 뽑고 출력
                PCard = trumpCard.ReRollCard();
                // } 플레이어 카드 뽑고 출력

                // { 라운드 결과 확인
                if(RoundResCheck(PCard, CCard1, CCard2))
                {
                    Console.WriteLine("플레이어의 승리!");
                    playerPoint += betPoint * 2;
                }
                else
                {
                    Console.WriteLine("플레이어의 패배!");
                }
                // } 라운드 결과 확인


                // 게임 종료 확인
                if (GameEndCheck())
                {
                    break;
                }   // 게임 종료 체크 조건문
            }   // 게임 메인 루프문
        }
        public bool GameEndCheck()
        {
            bool bIsGameOver = false;
            if (playerPoint >= 100000)
            {
                Console.WriteLine("플레이어가 100000만 포인트를 벌어 게임을 종료합니다.");
                bIsGameOver = true;
            }   
            else if(playerPoint <= 0)
            {
                Console.WriteLine("플레이어가 포인트를 모두 잃어 게임을 종료합니다.");
                bIsGameOver = true;
            }

            return bIsGameOver;
        }
        private int Bet()
        {
            int p = default;
            bool bIsLoopEnd = false;
            Console.WriteLine("현재 플레이어의 포인트 : {0}", playerPoint);
            while (!bIsLoopEnd)
            {
                Console.Write("베팅할 금액을 입력하세요 : ");
                int.TryParse(Console.ReadLine(), out p);

                if(p < 0)
                {
                    Console.WriteLine("[System Error] 베팅액은 음수가 될 수 없습니다.");
                }
                else if(p > playerPoint)
                {
                    Console.WriteLine("[System Error] 베팅액은 현재 가지고있는 포인트보다 클 수 없습니다.");
                }
                else
                {
                    bIsLoopEnd = true;
                }
            }
            

            return p;
        }

        private bool RoundResCheck(int p, int c1, int c2)
        {
            bool bIsPlayerWin = false;

            int higher = c1 > c2 ? c1:c2;
            int lower = c1 < c2 ? c1:c2;
            if(p < higher && p > lower)
            {
                bIsPlayerWin = true;
            }

            return bIsPlayerWin;
        }


    }
}
