using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Card
    {
        public string Name { get;}
        public int Value { get; }

        public Card(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}