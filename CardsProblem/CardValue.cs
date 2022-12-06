using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsProblem
{
    public class CardValue
    {
        private Dictionary<string, int> _cardsValue;
        public CardValue()
        {
            _cardsValue = new Dictionary<string, int>
            {
                /*My Cards & their Value*/
                { "A", 1 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 }
            };
        }
        public int NumberOfCards()
        {
            return _cardsValue.Count;
        }
        public string[] Names()
        {
            return _cardsValue.Keys.ToArray();
        }

        public int Value(string name)
        {
            return _cardsValue[name];
        }
    }
}
