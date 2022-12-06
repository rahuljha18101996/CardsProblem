namespace CardsProblem
{
    public class CardGame
    {
        private CardSet set;
        private int numberOfPlayer;
        private int numberOfCardToDeal;
        private bool distributeNoneCard;
        List<Card>[] cardsDistribution;
        private int index;
        private int winnerIndex;
        private int[] scores;
        public CardGame(CardSet set, int numberOfPlayer, int numberOfCardToDeal, bool distributeNoneCard = false)
        {
            this.winnerIndex = -1;
            this.index = 0;
            this.set = set;
            this.numberOfPlayer = numberOfPlayer;
            this.distributeNoneCard = distributeNoneCard;
            this.numberOfCardToDeal = numberOfCardToDeal;
            this.cardsDistribution = new List<Card>[this.numberOfPlayer];
            this.scores = new int[this.numberOfPlayer];
            for (int i = 0; i < this.numberOfPlayer; i++)
            {
                this.cardsDistribution[i] = new List<Card>();
            }
        }

        public void Deal()
        {
            int cardToDeal = this.numberOfPlayer * this.numberOfCardToDeal;
            int totalCard = set.TotalCard() - (distributeNoneCard ? 0 : set.NoneCard());
            if (cardToDeal > totalCard)
            {
                throw new Exception("Less Number Of Card To Distribute");
            }
            
            for (int i = 0; i < this.numberOfCardToDeal; i++)
            {
                for (int j = 0; j < this.numberOfPlayer; j++)
                {
                    cardsDistribution[j].Add(GetCard());
                }
            }
        }

        public void DealAgain(bool shuffle = true)
        {
            winnerIndex = -1;
            if (shuffle)
            {
                set.SuffleCard();
            }

            index = 0;
            for (int i = 0; i < cardsDistribution.Length; i++)
            {
                cardsDistribution[i].Clear();
            }
            Deal();
        }

        private Card GetCard()
        {
            if (distributeNoneCard)
            {
                return set.Cards()[index++];
            }
            else
            {
                while (set.Cards()[index].suit.Equals(Suit.None))
                {
                    index++;
                }
                return set.Cards()[index++];
            }
        }

        public void DisplayPlayerCard()
        {
            Console.WriteLine("Player's Cards");
            for (int j = 0; j < this.numberOfPlayer; j++)
            {
                Console.WriteLine($"Player {(j + 1)}");

                foreach (Card card in cardsDistribution[j])
                {
                    Console.WriteLine(card);
                }
            }
        }

        public void DisplayRemainingCard()
        {
            Console.WriteLine("Remaining Cards");
            HashSet<Card> s1 = new HashSet<Card>(set.Cards());
            HashSet<Card> s2 = new HashSet<Card>();

            foreach (List<Card> list in cardsDistribution)
            {
                foreach (Card c in list)
                {
                    s2.Add(c);
                }
            }

            foreach (Card card in s1.Except(s2))
            {
                Console.WriteLine(card);
            }
        }

        public void GetWinner()
        {
            int winnerSum = -1;
            for (int i = 0; i < cardsDistribution.Length; i++)
            {
                int t = 0;
                foreach (Card card in cardsDistribution[i])
                {
                    t += card.value;
                }

                if (t > winnerSum)
                {
                    winnerIndex = i;
                    winnerSum = t;
                }

                scores[i] = t;
            }
        }

        public void showWinner()
        {
            for (int i = 0; i < cardsDistribution.Length;i++)
            {
                if (i != winnerIndex)
                {
                    Console.WriteLine($"Player {i + 1} has Score {scores[i]}");
                }
                else
                {
                    Console.WriteLine($"Player {i + 1} is Winner with Score {scores[i]}");
                }
            }
        }
    }
}
