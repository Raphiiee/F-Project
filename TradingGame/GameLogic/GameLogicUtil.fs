module TradingGame.GameLogic.GameLogicUtil

open TradingGame.Card

let GetEfficiencyModifier (attackingCardType : uint, defendingCardType: uint) : float =
     
     if ((uint)(attackingCardType + (uint)1)%(uint)4) = defendingCardType then
         2
     else if ((uint)(attackingCardType - (uint)1)%(uint)4) = defendingCardType then
         0.5
     else
         1