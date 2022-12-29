module TradingGame_Tests.GameLogicTests.CalculateDamageGameLogicTests

open NUnit.Framework
open TradingGame.Card
open TradingGame.Enums.CardElementEnum
open TradingGame.GameLogic

[<Test>]
let GameLogicUtil_GetDamageDealtToDefenderDealsNoDamage_ReturnsMinus1 () =
    let CardDragon =  Card("Dragon", 1, 10, 2, 3, 5, 2, CardElementEnum.Air)
    let CardImp=  Card("Imp", 2,1,1,1, 1, 1, CardElementEnum.Air)
    let value = GameLogicUtil.CalculateDamageDealt(CardImp, CardDragon)
    Assert.AreEqual(-1, value)
    
[<Test>]
let GameLogicUtil_GetRoundsTillKoAttackerVeryEffective_Returns2 () =
    let CardDragon =  Card("Dragon", 1, 10, 0, 0, 0, 0, CardElementEnum.Air)
    let CardImp=  Card("Imp", 2, 1, 1, 1, 1, 1, CardElementEnum.Stone)
    let value = GameLogicUtil.CalculateDamageDealt(CardImp, CardDragon)
    Assert.AreEqual(2, value)