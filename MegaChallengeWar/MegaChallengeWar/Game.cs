using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game
    {
        Random r1 = new Random();
        Deck fullDeck = new Deck();
        private Player player1;
        private Player player2;

        //Overloaded constructor, initializes a new player with player name
        public Game(string player1Name, string player2Name)
        {
            player1 = new Player { PlayerName = player1Name };
            player2 = new Player { PlayerName = player2Name };
        }

        //Deal Cards and add it to the list for both the players.
        private void dealCards(Player player)
        {
            int randomCard = r1.Next(0, fullDeck.ListOfAllCards.Count);
            Card newCard = new Card
            {
                Suit = fullDeck.ListOfAllCards.ElementAt(randomCard).Suit,
                CardValue = fullDeck.ListOfAllCards.ElementAt(randomCard).CardValue,
                Face = fullDeck.ListOfAllCards.ElementAt(randomCard).Face
            };
            player.CardsWithPlayer.Add(newCard);
            fullDeck.ListOfAllCards.RemoveAt(randomCard);
        }

        //Format display, Print Ace for 1, Jack for 11 and so on.
        private string formatDealtCardString(Player player)
        {
            string result = "";
               result += String.Format("{0} is dealt with the {1} of {2}<br/>", player.PlayerName,
                   player.CardsWithPlayer.ElementAt(player.CardsWithPlayer.Count - 1).Face,
                   player.CardsWithPlayer.ElementAt(player.CardsWithPlayer.Count - 1).Suit);
            return result;
        }

        //Display the cards for both the players.
        public string DisplayDealtCards()
        {
            string result = "";
            while (fullDeck.ListOfAllCards.Count > 0)
            {
                dealCards(player1);
                result += formatDealtCardString(player1);

                dealCards(player2);
                result += formatDealtCardString(player2);
            }
            return result;
        }

        //Pass the list of cards with player1 and player2 to the Battle class
        public List<Card> StartBattle(string playerName)
        {
            if (playerName == "Player1") return player1.CardsWithPlayer;
            else return player2.CardsWithPlayer;
        }

    }
}