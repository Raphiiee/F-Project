module TradingGame_Tests.GameLogicTests.RoundsTillKoGameLogicTests

open System
open NUnit.Framework
open TradingGame.Card
open TradingGame.GameLogic
open TradingGame.Enums.CardElementEnum

[<Test>]
let GameLogicUtil_GetRoundsTillKoAttackerCantDamageDefender_ReturnsMinusOne () =
    let CardDragon =  Card("Dragon", 1, 10, 2, 3, 5, 2, CardElementEnum.Air)
    let CardImp=  Card("Imp", 2, 1, 1, 1, 1, 1, CardElementEnum.Air)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardImp, CardDragon)
    Assert.AreEqual(-1, value)
    
    
[<Test>]
let GameLogicUtilGetRoundsTillKoAttacker_DamagesDefenderByOne_Returns10 () =
    let CardDragon =  Card("Dragon", 1, 10, 2, 2, 5, 2, CardElementEnum.Air)
    let CardHuman=  Card("Human", 2, 1, 3, 1, 1, 1, CardElementEnum.Air)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardHuman, CardDragon)
    Assert.AreEqual(10, value)
    
[<Test>]
let GameLogicUtilGetRoundsTillKoAttacker_DamagesDefenderByOneAndIsFaster_Returns9 () =
    let CardDragon =  Card("Dragon", 1, 10, 2, 2, 5, 2, CardElementEnum.Air)
    let CardHuman=  Card("Human", 2, 2, 3, 2, 2,3, CardElementEnum.Air)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardHuman, CardDragon)
    Assert.AreEqual(9, value)