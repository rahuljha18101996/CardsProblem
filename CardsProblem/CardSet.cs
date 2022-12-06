namespace CardsProblem
{
    public class CardSet
    {
        private  Card[] cards;
        private CardValue cardValue;
        private int totalCard;
        private int noneCard;
        public CardSet(int noneCard)
        {
            this.noneCard = noneCard;
            cardValue = new CardValue();
            this.totalCard = noneCard + (Enum.GetValues(typeof(Suit)).Length - 1) * cardValue.NumberOfCards();
            cards = new Card[this.totalCard];
            Init();
        }

        public int TotalCard()
        {
            return totalCard;
        }

        public int NoneCard()
        {
            return noneCard;
        }

        public Card[] Cards() 
        { 
            return cards; 
        }


        public void Init()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                if (!s.Equals(Suit.None))
                {
                    InitCard(s,ref i);
                }
            }

            for (int j = 1; j <= this.noneCard; j++)
            {
                cards[i++] = new Card();
            }
        }

        private void InitCard(Suit suit,ref int start_index)
        {
            foreach (string name in cardValue.Names())
            {
                Card card = new Card()
                {
                    suit = suit,
                    value = cardValue.Value(name),
                    name = name
                };

                cards[start_index++] = card;
            }
        }
        public void DisplayCard()
        {
            foreach (Card c in cards)
            {
                Console.WriteLine(c);
            }
        }

        public void SuffleCard(int howManyShuffle = 54)
        {
            Random random = new Random();
            for (int i = 1; i <= howManyShuffle; i++)
            {
                int j = random.Next(0,cards.Length - 1);
                int k = random.Next(0,cards.Length - 1);
                if (j != k)
                {
                    Card temp = cards[j];
                    cards[j] = cards[k];
                    cards[k] = temp;
                }
            }
        }
    }
}
