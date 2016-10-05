using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck
    {     
        public List<Card> ListOfAllCards = new List<Card>();
        public List<Card> ListOfAllSuits = new List<Card>
        {
            new Card { Suit = "Spades" }, new Card { Suit = "Club" },
            new Card { Suit = "Diamond" }, new Card { Suit = "Heart" }
        };

        public List<Card> ListOfAllKinds = new List<Card>
        {
            new Card { CardValue = 14, Face = "Ace" }, new Card { CardValue = 2, Face = "2" }, new Card { CardValue = 3, Face = "3" },
            new Card { CardValue = 4, Face = "4" }, new Card { CardValue = 5, Face = "5" }, new Card { CardValue = 6, Face = "6" },
            new Card { CardValue = 7, Face = "7" }, new Card { CardValue = 8, Face = "8" }, new Card { CardValue = 9, Face = "9" },
            new Card { CardValue = 10, Face = "10" }, new Card { CardValue = 11, Face = "Jack" }, new Card { CardValue = 12, Face = "Queen" },
            new Card { CardValue = 13, Face = "King" }
        };

        public Deck()
        {
            foreach (var suit in ListOfAllSuits)
            {
                foreach (var kind in ListOfAllKinds)
                {
                    ListOfAllCards.Add(new Card { Suit = suit.Suit, CardValue = kind.CardValue, Face = kind.Face });
                }
            }
        }
        
    }
}