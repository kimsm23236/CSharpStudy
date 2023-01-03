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
        BackStraight,
        Mountain,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalStraightFlush
    }

    public class FHandType
    {
        public HandType handType;
        public int StraightNum;
        public string MostMark;
        public List<int> MostNum;
        public int HighestNum;

        public FHandType()
        {
            Init();
        }

        public void Init()
        {
            MostNum = new List<int>();
            handType = HandType.None;
            StraightNum = 0;
            MostMark = string.Empty;
            HighestNum = 0;
        }
        public string ResultStr()
        {
            string str = string.Empty;
            StringBuilder SB = new StringBuilder();

            string add = string.Empty;

            MostNum.Sort();
            MostNum.Reverse();

            switch(handType)
            {
                case HandType.RoyalStraightFlush:
                case HandType.StraightFlush:
                case HandType.Flush:
                    add = MostMark;
                    break;
            }
            SB.Append(add);
            SB.Append(" ");
            add = string.Empty;
            switch(handType)
            {
                case HandType.StraightFlush:
                case HandType.Straight:
                    add = StraightNum.ToString();
                    break;
                case HandType.FourOfAKind:
                case HandType.FullHouse:
                case HandType.ThreeOfAKind:
                case HandType.TwoPair:
                case HandType.OnePair:
                    add = MostNum[0].ToString();
                    break;
                case HandType.HighCard:
                    add = HighestNum.ToString();
                    break;
            }
            if (add == "1")
                add = "A";
            else if (add == "11")
                add = "J";
            else if (add == "12")
                add = "Q";
            else if (add == "13")
                add = "K";
            SB.Append(add);
            SB.Append(" ");
            add = string.Empty;

            if (handType == HandType.TwoPair)
            {
                add = MostNum[1].ToString();
            }

            if (add == "1")
                add = "A";
            else if (add == "11")
                add = "J";
            else if (add == "12")
                add = "Q";
            else if (add == "13")
                add = "K";
            SB.Append(add);
            SB.Append(" ");

            SB.Append(handType.ToString());

            return SB.ToString();
        }

    }

    public class PokerPlayer
    {
        protected List<Card> OwnCards;
        protected string Name;
        public FHandType fHandType;
        protected HandType handType;
        
        public HandType HandType
        {
            get { return handType; }
        }

        public string GetName()
        { 
            return Name; 
        }

        public PokerPlayer() 
        {

        }

        public virtual void RoundInit()
        {
            handType = HandType.None;
            OwnCards = new List<Card>();
        }

        public virtual void TakeCard(Card addCard)
        {
            OwnCards.Add(addCard);
            SortCard();
            fHandType.Init();
            handType = HandsCheck();
        }

        public virtual void PrintCards(StringBuilder SB)
        {
            SB.Append(Name);
            SB.Append("의 카드       ");
            SB.Append(fHandType.ResultStr());
            SB.AppendLine("                       ");

            for (int i = 0; i < OwnCards.Count; i++)
            {
                SB.Append("====== ");
            }
            SB.AppendLine();
            for (int i = 0; i < OwnCards.Count; i++)
            {
                // string message = "<color=green>Message : </color>" + "메세지";
                // string mark = "<color=green>Message : </color>" + OwnCards[i].mark;
                SB.Append("|");
                SB.Append(OwnCards[i].mark);
                SB.Append(OwnCards[i].number.PadLeft(2));
                SB.Append("| ");
            }
            SB.AppendLine();
            for (int i = 0; i < OwnCards.Count; i++)
            {
                SB.Append("|");
                SB.Append(OwnCards[i].number.PadRight(2));
                SB.Append(OwnCards[i].mark);
                SB.Append("| ");
            }
            SB.AppendLine();
            for (int i = 0; i < OwnCards.Count; i++)
            {
                SB.Append("====== ");
            }
            SB.Append("        \n");

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

            bool IsRSF = false;
            bool IsSF = false;
            bool IsFourOfAKind = false;
            bool IsFullHouse = false;
            bool IsFlush = false;
            bool IsMountain = false;
            bool IsBackStraight = false;
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
            // { 포카드, 트리플, 투페어, 원페어, 풀하우스 체크
            for (int i = 1; i < CntNumber.Length; i++)
            {
                if (CntNumber[i] >= 4)
                {
                    IsFourOfAKind = true;
                    fHandType.MostNum.Add(i);
                }
                else if (CntNumber[i] >= 3)
                {
                    IsThreeOfAKind = true;
                    fHandType.MostNum.Add(i);
                    if (IsOwnPair)
                        IsFullHouse = true;
                }
                else if (CntNumber[i] >= 2)
                {
                    if (IsThreeOfAKind)
                        IsFullHouse = true;
                    else if (!IsOwnPair)
                    {
                        IsOwnPair = true;
                        fHandType.MostNum.Add(i);
                    }
                    else if (IsOwnPair)
                    {
                        IsTwoPair = true;
                        fHandType.MostNum.Add(i);
                    }
                }
            }
            // { 포카드, 트리플, 투페어, 원페어, 풀하우스 체크
            
            // { 플러쉬
            for (int i = 0; i < CntMark.Length; i++)
            {
                if (CntMark[i] >= 5)
                {
                    string[] Mark = new string[4] { "♠", "◆", "♥", "♣" };

                    IsFlush = true;
                    fHandType.MostMark = Mark[i];
                }
            }
            // } 플러쉬

            // { 스트레이트, 마운틴, 백스트레이트, 스티플, 로티플
            int CntContinuous = 0; // 연속 번호 갯수 체크용 변수
            bool IsContinuous = false;  // 연속 번호인지 확인용 변수

            for(int i = 1; i < CntNumber.Length + 4; i++)
            {
                int index = 1;
                if (i <= 13)
                    index = i;
                else
                    index = i % 13;

                if (IsContinuous && CntNumber[index] >= 1) // 연속된 수 체크
                {
                    CntContinuous++;
                }
                else if (!IsContinuous && CntNumber[index] >= 1) // 연속된 수의 시작 부분 체크
                {
                    CntContinuous++;
                    IsContinuous = true;
                }
                else // 모든 경우에 해당하지 않는경우 연속이 끊김
                {
                    IsContinuous = false;
                    CntContinuous = 0;
                }


                if (CntContinuous >= 5)
                {
                    fHandType.StraightNum = index;
                    IsStraight = true;
                    // 스티플
                    if(IsFlush)
                        IsSF = true;
                    // 마운틴, 백, 로티플 체크
                    if(index == 1)
                    {
                        IsMountain = true;
                        if(IsFlush)
                            IsRSF = true;
                    }
                    else if(index == 5)
                    {
                        IsBackStraight = true;
                    }
                }
            }
            // } 스트레이트

            // { 하이 체크
            int high = 2;
            for(int i = 1; i < CntNumber.Length; i++)
            {
                if(CntNumber[i] < 1)
                    continue;
                if(high < i )
                    high = i;
            }
            if (CntNumber[1] >= 1)
                high = 1;

            fHandType.HighestNum = high;
            // } 하이 체크

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
            if(IsBackStraight)
                Result = HandType.BackStraight;
            if(IsMountain) 
                Result = HandType.Mountain;
            if(IsFlush)
                Result = HandType.Flush;
            if(IsFullHouse)
                Result = HandType.FullHouse;
            if(IsFourOfAKind)
                Result = HandType.FourOfAKind;
            if(IsSF)
                Result = HandType.StraightFlush;
            if (IsRSF)
                Result = HandType.RoyalStraightFlush;

            fHandType.handType = Result;

            return Result;
        } 
    }   // PokerPlayer

    public class PP_Player : PokerPlayer
    {
        private int ChoiceNum;
        private int cntChange;
        private bool bIsEndChange;

        public bool IsEndChange
        {
            get { return bIsEndChange; }
        }

        private Controller controller;
        public bool IsChoice;
        public PP_Player(string name) 
        {
            IsChoice = false;
            ChoiceNum = 0;
            cntChange = 40;
            Name = name;
            controller = Controller.Instance;
            OwnCards = new List<Card>();
            fHandType = new FHandType();
        }

        public override void RoundInit()
        {
            IsChoice = false;
            bIsEndChange = false;
            base.RoundInit();
            ChoiceNum = 0;
            cntChange = 2;
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
                    if(cntChange > 0)
                    {
                        OwnCards[ChoiceNum] = tc.RollCard();
                        fHandType.Init();
                        handType = HandsCheck();
                        cntChange--;
                    }
                    break;
                case ConsoleKey.C:
                    bIsEndChange = true;
                    IsChoice = false;
                    break;
                default:
                    break;
            }
        }

        public override void PrintCards(StringBuilder SB)
        {
            // 단순한 문자 출력에서 그래픽 출력?으로 바꾸기
            //==========
            //|♠ 2|
            //|2 ♠|
            //=====

            base.PrintCards(SB);

            if (IsChoice)
            {
                SB.Append("  ");
                for (int i = 0; i < ChoiceNum; i++)
                {
                    SB.Append("       ");
                }
                SB.Append("↑");
                SB.Append("                               ");
                SB.AppendLine("");
                SB.AppendLine("방향키로 교체할 카드를 정하신 후 Z키로 카드를 교체합니다.\n교체를 종료하실 경우 C키");
            }
        }

    }   // PP_Player

    public class PP_Enemy : PokerPlayer
    {
        public PP_Enemy(string name)
        {
            Name = name;
            OwnCards = new List<Card>();
            fHandType = new FHandType();
        }

        public override void PrintCards(StringBuilder SB)
        {
            base.PrintCards(SB);
            //foreach (Card card in OwnCards)
            //{
            //    SB.Append(card.mark + " " + card.number + " ");
            //}
            //SB.Append("                     ");
            //SB.AppendLine("");
        }

        public override void ExecuteIhrBehavior(TrumpCard tc)
        {
            base.ExecuteIhrBehavior(tc);
            TakeCard(tc.RollCard());
            TakeCard(tc.RollCard());
        }

    }   // PP_Enemy

}
