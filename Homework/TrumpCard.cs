using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class TrumpCard
    {
        public int[] Deck;
        private string[] Mark;

        public TrumpCard() 
        {
            Deck = new int[52];
            for(int i = 0; i <= Deck.GetUpperBound(0); i++)
            {
                Deck[i] = i + 1;
            }

            Mark = new string[4] { "♥", "◆", "♠", "♣" };
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
                Deck = ShuffleOnce(Deck);
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

        public int ReRollCard()
        {
            ShuffleCard();
            return RollCard();
        }

        public int RollCard()
        {
            int card = Deck[0];
            string mark = Mark[(card - 1) / 13];
            string cardNum = Math.Ceiling(card % 13.1).ToString();

            switch(cardNum)
            {
                case "11":
                    cardNum = "J";
                    break;
                case "12":
                    cardNum = "Q";
                    break;
                case "13":
                    cardNum = "K";
                    break;
            }

            Console.WriteLine("뽑은 카드는 {0} {1} 입니다.", mark, cardNum);
            int intCardNum = 0;
            int.TryParse(Math.Ceiling(card % 13.1).ToString(), out intCardNum);
            return intCardNum;

        }

        public void PrintDeck()
        {
            char ch = ' ';
            for (int i = 0; i <= Deck.GetUpperBound(0); i++)
            {
                if (Deck[i] / 13 <= 0)
                {
                    ch = '♥';
                }
                else if (Deck[i] / 13 < 1)
                {
                    ch = '◆';
                }
                else if (Deck[i] / 13 < 2)
                {
                    ch = '♠';
                }   
                else
                {
                    ch = '♣';
                }
                Console.WriteLine("{0} {1}", ch, (Deck[i] % 13) + 1);
            }
        }
    }
}
