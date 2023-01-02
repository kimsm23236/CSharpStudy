using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class PokerPlayer
    {
        protected List<Card> OwnCards;
        protected string Name;

        public PokerPlayer() 
        {

        }

        public virtual void TakeCard(Card addCard)
        {
            OwnCards.Add(addCard);
            SortCard();
        }

        public virtual void PrintCards(StringBuilder SB)
        {
            SB.Append(Name);
            SB.Append("의 카드                   \n");
            foreach (Card card in OwnCards)
            {
                SB.Append(card.mark + " " + card.number + " ");
            }
            SB.Append("            \n");
        }

        public void SortCard()
        {
            List<Card> newList = OwnCards.OrderBy(i => i.index).ToList();
            OwnCards = newList;
        }

        public virtual void ExecuteIhrBehavior(TrumpCard tc) // 고유 행동 * Inherence Behavior
        {
            
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
            SB.Append(Name);
            SB.Append("의 카드             \n");
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
                SB.Append("↑               \n");
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

        public override void ExecuteIhrBehavior(TrumpCard tc)
        {
            base.ExecuteIhrBehavior(tc);
            TakeCard(tc.RollCard());
            TakeCard(tc.RollCard());
        }

    }   // PP_Enemy

}
