module TradingGame_Tests.GameLogicTests.Effectiveness

open NUnit.Framework
open TradingGame.GameLogic

[<Test>]
let ``GameLogicUtilGetEffectiveness_SameType_Returns1`` () =
    let value = GameLogicUtil.GetEffectivenessModifier((uint)1 , (uint) 1)
    Assert.AreEqual(value, 1)
    
[<Test>]
let ``GameLogicUtilGetEffectiveness_VeryEffectiveWithOverflow_Returns2`` () =
    let value = GameLogicUtil.GetEffectivenessModifier((uint)3 , (uint) 0)
    Assert.AreEqual(value, 2)

[<Test>]
let ``GameLogicUtilGetEffectiveness_IneffectiveWithOverflow_Returns05`` () =
    let value = GameLogicUtil.GetEffectivenessModifier((uint)0 , (uint) 3)
    Assert.AreEqual(value, 0.5)

[<Test>]
let ``GameLogicUtilGetEffectiveness_normal_Returns1`` () =
    let value = GameLogicUtil.GetEffectivenessModifier((uint)3 , (uint) 1)
    Assert.AreEqual(value, 1)