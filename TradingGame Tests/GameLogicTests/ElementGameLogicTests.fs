module TradingGame_Tests.GameLogicTests.Effectiveness

open NUnit.Framework
open TradingGame.Enums.CardElementEnum
open TradingGame.GameLogic

[<Test>]
let ``GameLogicUtilGetEffectiveness_SameType_Returns1`` () =
    let value = GameLogicUtil.GetEffectivenessModifier(CardElementEnum.Air ,  CardElementEnum.Air)
    Assert.AreEqual(value, 1)
    
[<Test>]
let ``GameLogicUtilGetEffectiveness_VeryEffectiveWithOverflow_Returns2`` () =
    let value = GameLogicUtil.GetEffectivenessModifier(CardElementEnum.Water ,  CardElementEnum.Fire)
    Assert.AreEqual(value, 2)

[<Test>]
let ``GameLogicUtilGetEffectiveness_IneffectiveWithOverflow_Returns05`` () =
    let value = GameLogicUtil.GetEffectivenessModifier(CardElementEnum.Fire , CardElementEnum.Water)
    Assert.AreEqual(value, 0.5)

[<Test>]
let ``GameLogicUtilGetEffectiveness_normal_Returns1`` () =
    let value = GameLogicUtil.GetEffectivenessModifier(CardElementEnum.Fire , CardElementEnum.Air)
    Assert.AreEqual(value, 1)