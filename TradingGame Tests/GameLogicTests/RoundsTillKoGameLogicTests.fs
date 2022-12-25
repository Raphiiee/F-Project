module TradingGame_Tests.GameLogicTests.RoundsTillKoGameLogicTests

open System
open NUnit.Framework
open TradingGame.Card
open TradingGame.GameLogic

let CardHuman =  Card("Human", 5, 1, 5, 1, 1)

[<Test>]
let GameLogicUtil_GetRoundsTillKoAttackerCantDamageDefender_ReturnsMinusOne () =
    let CardDragon =  Card("Dragon", 10, 2, 3, 5, 2)
    let CardImp=  Card("Imp", 1, 1, 1, 1, 1)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardImp, CardDragon)
    Assert.AreEqual(-1, value)
    
    
[<Test>]
let GameLogicUtilGetRoundsTillKoAttacker_DamagesDefenderByOne_Returns10 () =
    let CardDragon =  Card("Dragon", 10, 2, 2, 5, 2)
    let CardHuman=  Card("Human", 1, 3, 1, 1, 1)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardHuman, CardDragon)
    Assert.AreEqual(10, value)
    
[<Test>]
let GameLogicUtilGetRoundsTillKoAttacker_DamagesDefenderByOneAndIsFaster_Returns9 () =
    let CardDragon =  Card("Dragon", 10, 2, 2, 5, 2)
    let CardHuman=  Card("Human", 1, 3, 1, 1,3)
    let value = GameLogicUtil.CalculateRoundsTillKo(CardHuman, CardDragon)
    Assert.AreEqual(9, value)