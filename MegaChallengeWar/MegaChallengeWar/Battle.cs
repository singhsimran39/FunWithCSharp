using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {
        private List<Card> cardsWithPlayer1 = new List<Card>();
        private List<Card> cardsWithPlayer2 = new List<Card>();
        
        //Overoaded constructor, take the cards for both players from the Game class
        public Battle(Game FromGameToBattle)
        {
            cardsWithPlayer1 = FromGameToBattle.StartBattle("Player1");
            cardsWithPlayer2 = FromGameToBattle.StartBattle("Player2");
        }

        //Start 20 turns
        public string startTwentyBattles()
        {
            string result = String.Format("<h3>Begin battle ...</h3><br/><br/>");
            int iCount = 0;
            for (int iTurn = 0; iTurn < 20; iTurn++)
            {
                result += String.Format("Battle Cards: {0} of {1} versus {2} of {3}</br>",
                    cardsWithPlayer1.ElementAt(iCount).Face, cardsWithPlayer1.ElementAt(iCount).Suit, 
                    cardsWithPlayer2.ElementAt(iCount).Face, cardsWithPlayer2.ElementAt(iCount).Suit);
                result += compareBattleCards(iCount);
            }
            result += countCards();
            
            return result;
        }

        //Compare Player cards and call print methods
        private string compareBattleCards(int iCount, string recursiveCall = "")
        {
            string result = "";
            if (cardsWithPlayer1.ElementAt(iCount).CardValue > cardsWithPlayer2.ElementAt(iCount).CardValue)
                return helperMethod("Player1", iCount, recursiveCall);

            else if (cardsWithPlayer2.ElementAt(iCount).CardValue > cardsWithPlayer1.ElementAt(iCount).CardValue)
                return helperMethod("Player2", iCount, recursiveCall);

            else
            {
                result += printWarBounty(iCount);
                result += compareBattleCards(iCount + 3, "RecursiveCall");
                return result;
            }
        }
        
        //Calls other methods.
        private string helperMethod(string playerName, int iCount, string recursiveCall = "")
        {
            string result = "";
            if (recursiveCall == "RecursiveCall" && playerName == "Player1") result += player1CardGreater(iCount, "RecursiveCall");
            else if (recursiveCall == "" && playerName == "Player1") result += player1CardGreater(iCount);
            else if (recursiveCall == "RecursiveCall" && playerName == "Player2") result += player2CardGreater(iCount, "RecursiveCall");
            else result += player2CardGreater(iCount);

            return result;
        }

        //When player 1 is greater call print plaer 1 win and add remove cards method
        private string player1CardGreater(int iCount, string recursiveCall = "")
        {
            string result = "";
            if (recursiveCall == "RecursiveCall")
            {
                result += String.Format("<span style='color:red;font-weight:bolder;'>Player1 wins!</span></br></br>");
                addRemoveCards(cardsWithPlayer1, cardsWithPlayer2, iCount);
            }

            else
            {
                result += printNormalBounty(iCount);
                result += String.Format("<span style='color:red;font-weight:bolder;'>Player1 wins!</span></br></br>");
                addRemoveCards(cardsWithPlayer1, cardsWithPlayer2, iCount);
            }

            return result;
        }

        //When player 2 is greater call print plaer 1 win and add remove cards method
        private string player2CardGreater(int iCount, string recursiveCall = "")
        {
            string result = "";
            if (recursiveCall == "RecursiveCall")
            {
                result += String.Format("<span style='color:blue;font-weight:bolder;'>Player2 wins!</span></br></br>");
                addRemoveCards(cardsWithPlayer2, cardsWithPlayer1, iCount);
            } 

            else
            {
                result += printNormalBounty(iCount);
                result += String.Format("<span style='color:blue;font-weight:bolder;'>Player2 wins!</span></br></br>");
                addRemoveCards(cardsWithPlayer2, cardsWithPlayer1, iCount);
            }

            return result;
        }

        //PRint bounty in normal case
        private string printNormalBounty(int iCount)
        {
            string result = "";
            result = String.Format("Bounty ...</br>&nbsp &nbsp {0} of {1}</br>&nbsp &nbsp {2} of {3}</br>",
                cardsWithPlayer1.ElementAt(iCount).Face, cardsWithPlayer1.ElementAt(iCount).Suit,
                cardsWithPlayer2.ElementAt(iCount).Face, cardsWithPlayer2.ElementAt(iCount).Suit);
                return result;
        }

        //Print bounty when war
        private string printWarBounty(int iCount)
        {
            string result = "</br>************WAR***************</br></br>";
            result += String.Format("Battle Cards: {0} of {1} versus {2} of {3}</br>", 
                cardsWithPlayer1.ElementAt(iCount + 3).Face, cardsWithPlayer1.ElementAt(iCount + 3).Suit,
                cardsWithPlayer2.ElementAt(iCount + 3).Face, cardsWithPlayer2.ElementAt(iCount + 3).Suit);
            result += String.Format("Bounty ...</br> ");
            for (int i = 0; i < 4; i++)
            {
                result += string.Format("&nbsp&nbsp{0} of {1}</br> &nbsp&nbsp{2} of {3}</br> ",
                    cardsWithPlayer1.ElementAt(iCount).Face, cardsWithPlayer1.ElementAt(iCount).Suit,
                    cardsWithPlayer2.ElementAt(iCount).Face, cardsWithPlayer2.ElementAt(iCount).Suit);
                iCount++;
            }
            return result;
        }

        //add remove cards from the list
        private void addRemoveCards(List<Card> addInList, List<Card> removeFromList, int iCount)
        {
            for (int i = 0; iCount - i >= 0 ; i++)
            {
                addInList.Add(removeFromList.ElementAt(iCount - i));
                removeFromList.RemoveAt(iCount - i);
                addInList.Add(addInList.ElementAt(iCount - i));
                addInList.RemoveAt(iCount - i);
            }
        }

        //count cards and print winner
        private string countCards()
        {
            string result = "";
            if (cardsWithPlayer1.Count > cardsWithPlayer2.Count)
                result += printWinner("Player1", cardsWithPlayer1, "Player2", cardsWithPlayer2);

            else if (cardsWithPlayer2.Count > cardsWithPlayer1.Count)
                result += printWinner("Player2", cardsWithPlayer2, "Player1", cardsWithPlayer1);

            else
                result += String.Format("<span style='color:Green;font-weight:bolder;'>LOL.... Match Draw</span>");

            return result;
        }

        //Print to screen the winner 
        private string printWinner(string winnerName, List<Card> winnerList, string loserName, List<Card> loserList)
        {
            string result = "";
            if (winnerName == "Player1")
            result += String.Format("<span style='color:red;font-weight:bolder;'>{0} wins the game</br>{1}: {2}</span></br>" +
                    "<span style='color:blue;font-weight:bolder;'>{3}: {4}</span>",
                    winnerName, winnerName, winnerList.Count, loserName, loserList.Count);
            else
                result += String.Format("<span style='color:blue;font-weight:bolder;'>{0} wins the game</br>{1}: {2}</span></br>" +
                    "<span style='color:red;font-weight:bolder;'>{3}: {4}</span>",
                    winnerName, winnerName, winnerList.Count, loserName, loserList.Count);
            return result;
        }
    }
}