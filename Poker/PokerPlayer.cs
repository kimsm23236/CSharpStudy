using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum HandType
    {
        None,
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FourOfAKind,
    }

    public class PokerPlayer
    {
        protected List<Card> OwnCards;
        protected string Name;
        protected HandType handType;
        

        public PokerPlayer() 
        {

        }

        public virtual void TakeCard(Card addCard)
        {
            OwnCards.Add(addCard);
            SortCard();
            handType = HandsCheck();
        }

        public virtual void PrintCards(StringBuilder SB)
        {
            SB.Append(Name);
            SB.Append("의 카드       ");
            SB.Append(handType.ToString());
            SB.AppendLine("                       ");
        }

        public void SortCard()
        {
            List<Card> newList = OwnCards.OrderBy(i => i.index).ToList();
            OwnCards = newList;
        }

        public virtual void ExecuteIhrBehavior(TrumpCard tc) // 고유 행동 * Inherence Behavior
        {
            
        }

        public virtual HandType HandsCheck()
        {
            HandType Result = HandType.None;

            bool IsFourOfAKind = false;
            bool IsFlush = false;
            bool IsStraight = false;
            bool IsThreeOfAKind = false;
            bool IsTwoPair = false;
            bool IsOwnPair = false;

            int[] CntNumber = new int[14]; // 1~K [1] ~ [13]
            int[] CntMark = new int[4]; // 스페이드, 다이아, 하트, 클로버

            foreach (var card in OwnCards) // 카드마다 반복
            {
                // 숫자 카운트 배열 증가 
                CntNumber[(int)Math.Ceiling(card.index % 13.1)]++;
                // 문양 카운트 배열 증가
                CntMark[((card.index - 1) / 13)]++;
            }
            // { 포카드, 트리플, 투페어, 원페어 체크
            
            for(int i = 1; i < CntNumber.Length; i++)
            {
                if (CntNumber[i] >= 4)
                    IsFourOfAKind = true;
                if (CntNumber[i] >= 3)
                    IsThreeOfAKind = true;
                if (CntNumber[i] >= 2)
                {
                    if(!IsOwnPair)
                        IsOwnPair = true;
                    else if(IsOwnPair)
                        IsTwoPair = true;
                }
            }
            // } 포카드
            // { 플러쉬
            for(int i = 0; i < CntMark.Length; i++)
            {
                if (CntMark[i] >= 5)
                    IsFlush = true;
            }
            // } 플러쉬
            // { 스트레이트
            int CntContinuous = 0; // 연속 번호 갯수 체크용 변수
            bool IsContinuous = false;  // 연속 번호인지 확인용 변수
            for(int i = 1; i < CntNumber.Length; i++)
            {
                if(CntContinuous >= 5)
                {
                    IsStraight = true;
                }

                if (IsContinuous && CntNumber[i] >= 1) // 연속된 수 체크
                {
                    CntContinuous++;
                    continue;
                }
                else if(!IsContinuous && CntNumber[i] >= 1) // 연속된 수의 시작 부분 체크
                {
                    CntContinuous++;
                    IsContinuous = true;
                    continue;
                }
                // 모든 경우에 해당하지 않는경우 연속이 끊김
                IsContinuous = false;
                CntContinuous = 0;

            }
            // } 스트레이트

            // 검증된 결과중 서열이 낮은것 부터 검사하면서 붙여넣는 식으로 결과 결정
            if(!IsFlush && !IsStraight && !IsOwnPair)
                Result = HandType.HighCard;
            if(IsOwnPair)
                Result = HandType.OnePair;
            if(IsTwoPair)
                Result = HandType.TwoPair;
            if(IsThreeOfAKind)
                Result = HandType.ThreeOfAKind;
            if(IsStraight)
                Result = HandType.Straight;
            if(IsFlush)
                Result = HandType.Flush;
            if(IsFourOfAKind)
                Result = HandType.FourOfAKind;
            
            return Result;
        } 
    }   // PokerPlayer

    public class PP_Player : PokerPlayer
    {
        private int ChoiceNum;
        private Controller controller;
        public bool IsChoice;
        public PP_Player(string name) 
        {
            IsChoice = false;
            ChoiceNum = 0;
            Name = name;
            controller = Controller.Instance;
            OwnCards = new List<Card>();
        }

        public override void ExecuteIhrBehavior(TrumpCard tc)
        {
            base.ExecuteIhrBehavior(tc);
            controller.KbHit();
            if (!controller.IsKeyDown)
                return;
            switch(controller.CKI.Key)
            {
                case ConsoleKey.LeftArrow:
                    ChoiceNum = Math.Clamp(ChoiceNum - 1, 0, 4);
                    break; 
                case ConsoleKey.RightArrow:
                    ChoiceNum = Math.Clamp(ChoiceNum + 1, 0, 4);
                    break;
                case ConsoleKey.Z:
                    OwnCards[ChoiceNum] = tc.RollCard();
                    break;
                default:
                    break;
            }
        }

        public override void PrintCards(StringBuilder SB)
        {
            base.PrintCards(SB);
            foreach (Card card in OwnCards)
            {
                SB.Append(card.mark + " " + card.number + " ");
            }
            SB.Append("        \n");

            if (IsChoice)
            {
                SB.Append(" ");
                for (int i = 0; i < ChoiceNum; i++)
                {
                    SB.Append("     ");
                }
                SB.Append("↑");
                SB.Append("                               ");
                SB.AppendLine("");
            }
        }

    }   // PP_Player

    public class PP_Enemy : PokerPlayer
    {
        public PP_Enemy(string name)
        {
            Name = name;
            OwnCards = new List<Card>();
        }

        public override void PrintCards(StringBuilder SB)
        {
            base.PrintCards(SB);
            foreach (Card card in OwnCards)
            {
                SB.Append(card.mark + " " + card.number + " ");
            }
            SB.Append("                     ");
            SB.AppendLine("");
        }

        public override void ExecuteIhrBehavior(TrumpCard tc)
        {
            base.ExecuteIhrBehavior(tc);
            TakeCard(tc.RollCard());
            TakeCard(tc.RollCard());
        }

    }   // PP_Enemy

}
