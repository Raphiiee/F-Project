module TradingGame_Tests.GameLogicTests.HealthLeftGameLogicTests


open NUnit.Framework
open TradingGame.Card

open TradingGame.Enums.CardElementEnum
open TradingGame.GameLogic

[<Test>]
let GameLogicUtilRemainingHealthOfWinner_SameValues_Returns1 () =
    let CardDragon =  Card("Dragon", 1, 10, 2, 2, 5, 2, CardElementEnum.Air)
    let CardHuman=  Card("Human", 2, 10, 3, 1, 1,3, CardElementEnum.Air)
    let roundsToKill = GameLogicUtil.CalculateRoundsTillKo(CardHuman, CardDragon)
    let value = GameLogicUtil.CalculateHealthLeft(CardHuman, CardDragon, roundsToKill)
    Assert.AreEqual(1, value)