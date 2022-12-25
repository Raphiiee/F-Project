module TradingGame_Tests.GameLogicTests

open NUnit.Framework
open NUnit.Framework.Internal
open TradingGame.GameLogic

[<Test>]
let ``GameLogicUtil_GetEfficiency_Returns1`` () =
    let value = GameLogicUtil.GetEfficiencyModifier((uint)1 , (uint) 1)
    Assert.AreEqual(value, 1)
    
[<Test>]
let ``GameLogicUtil_GetEfficiencyWithOverflow_Returns2`` () =
    let value = GameLogicUtil.GetEfficiencyModifier((uint)3 , (uint) 0)
    Assert.AreEqual(value, 2)

[<Test>]
let ``GameLogicUtil_GetEfficiencyWithOverflow_Returns05`` () =
    let value = GameLogicUtil.GetEfficiencyModifier((uint)0 , (uint) 3)
    Assert.AreEqual(value, 0.5)