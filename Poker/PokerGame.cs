using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
        // 플레이어
        private PP_Player Player;
        // 상대
        private PP_Enemy[] Enemies;
        // 모든 플레이어
        private PokerPlayer[] PokerPlayers;
        // 라운드 별 승자를 저장할 변수
        private PokerPlayer RoundWinner;
        // 트럼프 카드 객체
        private TrumpCard trumpCard;

        // Count PokerPlayer * 게임 인원수 변수
        private int cntPP = 0;
        // 플레이어 포인트 변수
        private int Point = 0;
        // 플레이어 베팅 포인트 변수
        private int betP = 0;
        // 플레이어 목표 포인트 상수
        private const int EndPoint = 100000;

        // 상대 이름 배열
        private string[] names = { "적 1", "적 2", "적 3" };
        // 고유 행동 페이즈에서 상대의 턴인지 플레이어의 턴인지 결정하는 변수
        private bool bIsPlayerSelect;
        // 페이즈 별로 한번 처리해야 하는 경우가 있어 선언한 변수
        private bool PhaseOneProcess;
        // 게임이 끝났는지를 Main메서드에 알려주기 위한 변수
        private bool bIsGameEnd;
        public bool IsGameEnd // 위에꺼 private 으로 해놔서 밖에서 겟하기 위한 프로퍼티
        {
            get { return bIsGameEnd; }
        }
        
        // 페이즈 열거 변수
        private EPHASE CurrentPhase = EPHASE.None;

        public PokerGame() // 생성자, 초기화
        {
            bIsGameEnd = false;
            bIsPlayerSelect = false;
            PhaseOneProcess = false;
        }
        public override void Init()
        {
            base.Init();
            // 트럼프 카드 초기화 작업
            trumpCard = new TrumpCard();    // 객체 생성 후
            trumpCard.ShuffleCard();        // 카드를 섞고 
            trumpCard.SetDeck();            // 게임에서 사용할 덱으로 설정

            // 게임 인원 입력 루프
            while(cntPP < 2) // 2 이상일 때 까지
            {
                Console.Write("게임 인원을 입력 (2 ~ 4) : ");
                int.TryParse(Console.ReadLine(), out cntPP);
                if(cntPP >= 2  && cntPP < 5) // 잘못된 범위가 아니라면 빠져나감
                {
                    break;
                }
                else
                {
                    Console.WriteLine("[System Error] 입력이 잘못되었습니다.");
                }
            }
            
            Player = new PP_Player("Player");
            Enemies = new PP_Enemy[cntPP-1];
            Point = 10000;

            for(int i = 0; i < cntPP - 1; i++)
            {
                Enemies[i] = new PP_Enemy(names[i]);
            }

            PokerPlayers = new PokerPlayer[cntPP];
            PokerPlayers[cntPP - 1] = Player;
            for(int i = 0; i < cntPP - 1; i++)
            {
                PokerPlayers[i] = Enemies[i];
            }

            PhaseShift(EPHASE.DRAW);
            
        }
        public override void Update() 
        {
            //PrintAllPlayersCard();

            switch (CurrentPhase)
            {
                case EPHASE.DRAW:
                    prc_Draw();
                    break;
                case EPHASE.BET:
                    PrintAllPlayersCard();
                    prc_Bet();
                    break;
                case EPHASE.INBH:
                    PrintAllPlayersCard();
                    prc_Inbh();
                    break;
                case EPHASE.ROUNDEND:
                    PrintAllPlayersCard();
                    prc_RoundEnd();
                    break;
                case EPHASE.GETREWARD:
                    prc_GetReward();
                    break;
                case EPHASE.GAMEEND:
                    prc_GameEnd();
                    break;
                default: 
                    break;
            }
        }

        public override void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(50);
            stringBuilder = new StringBuilder();
        }

        public void PrintAllPlayersCard()
        {
            for (int i = 0; i < cntPP; i++)
            {
                PokerPlayers[i].PrintCards(stringBuilder);
            }
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
            stringBuilder.Clear();
            for (int i = 0; i < cntPP; i++)
            {
                PokerPlayers[i].PrintCards(stringBuilder);
            }
            PhaseShift(EPHASE.BET);
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
                    Point -= betP;
                    isSuccessBet = true;
                }
                else
                {
                    Console.WriteLine("[System Error] 베팅 금액이 잘못되었습니다.");
                }
            }
            PhaseShift(EPHASE.INBH);
        }
        private void prc_Inbh()
        {

            // 컴퓨터 두장 뽑기
            if(!bIsPlayerSelect)
            {
                for (int i = 0; i < cntPP-1; i++)
                {
                    PokerPlayers[i].ExecuteIhrBehavior(trumpCard);
                }
                bIsPlayerSelect = true;
                PP_Player player = (PP_Player)PokerPlayers[cntPP-1];
                player.IsChoice = true;
            }
            else // 플레이어 초이스 작업
            {
                PokerPlayers[cntPP-1].ExecuteIhrBehavior(trumpCard);
            }
            if(Player.IsEndChange)
            {
                Player.IsChoice = false;
                PhaseShift(EPHASE.ROUNDEND);
            }
            
        }
        private void prc_RoundEnd()
        {
            RoundWinner = WhoisWinner();
            stringBuilder.Append("승자는 ");
            stringBuilder.Append(RoundWinner.GetName());
            LineClear();
            stringBuilder.Append("Press Z to Next Phase");
            LineClear(3);

            Controller controller = Controller.Instance;
            controller.KbHit();
            if (!controller.IsKeyDown)
                return;
            if (controller.CKI.Key == ConsoleKey.Z)
            {
                PhaseShift(EPHASE.GETREWARD);
            }
        }

        private void prc_GetReward()
        {
            stringBuilder.Append("라운드 결과");
            LineClear();
            if (RoundWinner.Equals(PokerPlayers[cntPP - 1]))
            {
                stringBuilder.Append("베팅 금액의 두배를 얻으셨습니다.");
            }
            else
            {
                stringBuilder.Append("베팅 금액을 잃어버리셨습니다.");
            }
            LineClear();
            stringBuilder.Append("Press Z to NextPhase");
            LineClear(20);

            if (!PhaseOneProcess && RoundWinner.Equals(PokerPlayers[cntPP - 1]))
            {
                Point += (betP * 2);
                PhaseOneProcess = true;
            }

            Controller controller = Controller.Instance;

            controller.KbHit();
            if (!controller.IsKeyDown)
                return;

            if (controller.CKI.Key == ConsoleKey.Z)
            {
                if (Point > 0 && Point < EndPoint)
                {
                    trumpCard.SetupNewDeck();
                    PhaseShift(EPHASE.DRAW);
                    bIsPlayerSelect = false;
                    for(int i = 0; i < cntPP; i++)
                    {
                        PokerPlayers[i].RoundInit();
                    }
                    RoundWinner = new PokerPlayer();
                }
                else
                {
                    PhaseShift(EPHASE.GAMEEND);
                }
            }
        }

        private void prc_GameEnd()
        {
            stringBuilder.Append("게임 종료");
            LineClear();
            if(Point >= EndPoint)
                stringBuilder.Append("10만 포인트를 모아서 게임이 종료됩니다.");
            else
                stringBuilder.Append("포인트를 모두 잃어 게임이 종료됩니다.");

            LineClear();
            stringBuilder.Append("Press Z to Game Exit");
            LineClear(15);

            Controller controller = Controller.Instance;

            controller.KbHit();
            if (!controller.IsKeyDown)
                return;

            if (controller.CKI.Key == ConsoleKey.Z)
            {
                bIsGameEnd = true;
            }
        }

        private PokerPlayer WhoisWinner()
        {
            int index = 0;

            for(int i = 1; i < PokerPlayers.Length; i++)
            {
                if (PokerPlayers[i].HandType > PokerPlayers[index].HandType)
                {
                    index = i;
                }
            }
            return PokerPlayers[index];
        }

        private void PhaseShift(EPHASE next)
        {
            Console.Clear();
            PhaseOneProcess = false;
            CurrentPhase = next;
        }

        private void LineClear()
        {
            stringBuilder.AppendLine("                                                                       ");
        }
        private void LineClear(int line)
        {
            for(int i = 0; i < line; i++)
            {
                stringBuilder.AppendLine("                                                                     ");
            }
            
        }

    }
}
