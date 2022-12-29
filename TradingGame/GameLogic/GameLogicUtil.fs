module TradingGame.GameLogic.GameLogicUtil

open System
open TradingGame.Card
open TradingGame.Enums.CardElementEnum

let modulo ( x: int    , m: int) : int =
    (x%m + m)%m;

let  GetEffectivenessModifier (attackingCardType : CardElementEnum, defendingCardType: CardElementEnum) : float =
     
     let attackingCardElementValue = (int) attackingCardType
     let defendingCardElementValue = (int) defendingCardType
     if (attackingCardElementValue + 1)%4= defendingCardElementValue then
         2
     else if modulo((attackingCardElementValue - 1),4) = defendingCardElementValue then
         0.5
     else
         1
         
let CalculateDamageDealt (attackingCard: Card, defendingCard: Card) : int =
    if(attackingCard.Damage < defendingCard.Armor) then
        -1
    else
      let damageDealt : float = float(attackingCard.Damage - defendingCard.Armor)
      let effectiveDamageDealt = int (System.Math.Round(damageDealt * GetEffectivenessModifier(attackingCard.Element, defendingCard.Element), MidpointRounding.AwayFromZero))
      effectiveDamageDealt
      
let CalculateRoundsTillKo (attackingCard: Card, defendingCard: Card) : int =
    
    
        let damageDealt = CalculateDamageDealt(attackingCard, defendingCard)
        
        if damageDealt < 1 then
            -1
        else 
            let RoundsTillKo : int = (defendingCard.Health / damageDealt)
            
            if attackingCard.Speed > defendingCard.Speed && RoundsTillKo > 0 then
                (int)RoundsTillKo - 1
            else (int) RoundsTillKo

let CalculateHealthLeft (survivingCard: Card, dyingCard: Card, roundsTillKo : int) : int =
    let damageDealt = CalculateDamageDealt(dyingCard, survivingCard)
    if damageDealt < 1 then
        -1
    else
        survivingCard.Health - damageDealt*roundsTillKo