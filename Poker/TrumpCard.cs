using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public struct Card
    {
        public int index;
        public string number;
        public string mark;
    }
    public class TrumpCard
    {
        public List<Card> Deck;
        public int[] tempDeck;
        private string[] Mark;
 

        public TrumpCard() 
        {
            tempDeck = new int[52];
            Deck = new List<Card>();
            for(int i = 0; i <= tempDeck.GetUpperBound(0); i++)
            {
                tempDeck[i] = i + 1;
            }

            Mark = new string[4] { "♠", "◆", "♥", "♣" };
        }

        public void SetDeck() // 임시 덱을 게임에서 사용할 카드 구조체 배열로 넣어주기
        {
            for(int i = 0; i <= tempDeck.GetUpperBound(0); i++)
            {
                int card = tempDeck[i];
                string mark = Mark[(card - 1) / 13];
                int cardNum = Convert.ToInt32(Math.Ceiling(card % 13.1));
                string cardNumStr = Math.Ceiling(card % 13.1).ToString();
                Card SetCard = new Card();
                if(cardNum == 13)
                    cardNumStr = "K";
                else if (cardNum == 12)
                    cardNumStr = "Q";
                else if (cardNum == 11)
                    cardNumStr = "J";
                else if (cardNum == 1)
                    cardNumStr = "A";
                SetCard.index = card;
                SetCard.number = cardNumStr;
                SetCard.mark = mark;
                Deck.Add(SetCard);
            }
        }

        public void SetupNewDeck()
        {
            Deck = new List<Card>();
            tempDeck = newDeck();
            ShuffleCard();
            SetDeck();
        }

        public int[] newDeck()  // 
        {
            int[] newdeck = new int[52];

            for (int i = 0; i <= newdeck.GetUpperBound(0); i++)
            {
                newdeck[i] = i + 1;
            }

            return newdeck;
        }

        // 카드를 섞는 함수
        public void ShuffleCard()
        {
            ShuffleCard(200);
        }
        // 카드를 섞는 함수
        private void ShuffleCard(int howManyLoop)
        {
            for(int i = 0; i < howManyLoop; i++)
            {
                tempDeck = ShuffleOnce(tempDeck);
            }
        }

        private int[] ShuffleOnce(int[] Array)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, Array.Length);
            int destIndex = random.Next(0, Array.Length);

            int temp = Array[sourIndex];
            Array[sourIndex] = Array[destIndex];
            Array[destIndex] = temp;
            return Array;
        }

        //public int ReRollCard()
        //{
        //    ShuffleCard();
        //    return RollCard();
        //}

        public Card RollCard()
        {
            Card rollCard = Deck.Last();

            Deck.Remove(rollCard);

            return rollCard;
        }
    }
}
