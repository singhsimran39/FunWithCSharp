﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Card> CardsWithPlayer = new List<Card>();
    }
}