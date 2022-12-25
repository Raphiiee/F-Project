module TradingGame.GameLogic.GameLogicUtil

open TradingGame.Card

let GetEffectivenessModifier (attackingCardType : uint, defendingCardType: uint) : float =
     
     if ((uint)(attackingCardType + (uint)1)%(uint)4) = defendingCardType then
         2
     else if ((uint)(attackingCardType - (uint)1)%(uint)4) = defendingCardType then
         0.5
     else
         1

let CalculateRoundsTillKo (attackingCard: Card, defendingCard: Card) : int =
    
    if(attackingCard.Damage < defendingCard.Armor) then
        -1
    else
        let damageDealt = attackingCard.Damage - defendingCard.Armor
        
        let RoundsTillKo : int = (defendingCard.Health / damageDealt)
        
        if attackingCard.Speed > defendingCard.Speed && RoundsTillKo > 0 then
            (int)RoundsTillKo - 1
        else (int) RoundsTillKo