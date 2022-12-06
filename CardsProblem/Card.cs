using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsProblem
{
    public class Card
    {
        public Suit suit { get; set; } = Suit.None;
        public string name { get; set; } = "J";
        public int value { get; set; } = 0;

        public override string? ToString()
        {
            return $"Card[Suit = {this.suit}, Name = {this.name}, Value = {this.value}]";
        }

    }
}
