using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum EPHASE
    {
        None = 0,
        DRAW, BET, INBH, ROUNDEND, GETREWARD, GAMEEND
    }
    public class PokerGame : Game
    {
        private PP_Player Player;
        private PP_Enemy[] Enemies;
        private PokerPlayer[] PokerPlayers;
        private TrumpCard trumpCard;
        private int cntPP = 0;
        private int Point = 0;
        private int betP = 0;
        private string[] names = { "적 1", "적 2", "적 3" };
        private bool bIsPlayerSelect;

        private EPHASE CurrentPhase = EPHASE.None;

        public PokerGame() 
        {

        }
        public override void Init()
        {
            base.Init();
            // 트럼프 카드 초기화 작업
            trumpCard = new TrumpCard();
            trumpCard.ShuffleCard();
            trumpCard.SetDeck();


            while(cntPP < 2)
            {
                Console.Write("게임 인원을 입력 (2 ~ 4) : ");
                int.TryParse(Console.ReadLine(), out cntPP);
                if(cntPP >= 2  && cntPP < 5) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("[System Error] 입력이 잘못되었습니다.");
                }
            }
            
            Player = new PP_Player("김수민");
            Enemies = new PP_Enemy[cntPP-1];
            Point = 10000;

            for(int i = 0; i < cntPP - 1; i++)
            {
                Enemies[i] = new PP_Enemy(names[i]);
            }

            PokerPlayers = new PokerPlayer[cntPP];
            PokerPlayers[0] = Player;
            for(int i = 1; i < cntPP; i++)
            {
                PokerPlayers[i] = Enemies[i-1];
            }

            CurrentPhase = EPHASE.DRAW;
            
        }
        public override void Update() 
        {
            switch(CurrentPhase)
            {
                case EPHASE.DRAW:
                    prc_Draw();
                    break;
                case EPHASE.BET:
                    prc_Bet();
                    break;
                case EPHASE.INBH:
                    prc_Inbh();
                    break;
                case EPHASE.ROUNDEND: 
                    break;
                case EPHASE.GETREWARD:
                    break;
                case EPHASE.GAMEEND:
                    break;
                default: 
                    break;
            }
        }

        public override void Render()
        {
            

            for(int i = 0; i < cntPP; i++)
            {
                PokerPlayers[i].PrintCards(stringBuilder);
            }
            base.Render();
        }
        private void prc_Draw()
        {
            foreach (var pokerPlayer in PokerPlayers)
            {
                for (int i = 0; i < 5; i++)
                {
                    pokerPlayer.TakeCard(trumpCard.RollCard());
                }
            }
            CurrentPhase = EPHASE.BET;
        }
        private void prc_Bet()
        {
            bool isSuccessBet = false;
            while (!isSuccessBet)
            {
                Console.Write("베팅 금액을 입력하세요 (현재 포인트 : {0}) : ", Point);
                int.TryParse(Console.ReadLine(), out betP);
                if (betP >= 0 && betP <= Point)
                {
                    isSuccessBet = true;
                }
                else
                {
                    Console.WriteLine("[System Error] 베팅 금액이 잘못되었습니다.");
                }
            }
            CurrentPhase = EPHASE.INBH;
        }
        private void prc_Inbh()
        {

            // 컴퓨터 두장 뽑기
            if(!bIsPlayerSelect)
            {
                for (int i = 1; i < cntPP; i++)
                {
                    PokerPlayers[i].ExecuteIhrBehavior(trumpCard);
                }
                bIsPlayerSelect = true;
                PP_Player player = (PP_Player)PokerPlayers[0];
                player.IsChoice = true;
            }
            else // 플레이어 초이스 작업
            {
                PokerPlayers[0].ExecuteIhrBehavior(trumpCard);
            }
        }
    }
}
