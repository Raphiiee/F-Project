module TradingGame_Tests.UtilsTests.UtilsTests

open NUnit.Framework
open Utils

[<Test>]
[<TestCase("AAAAAAAA")>]
[<TestCase("1A")>]
[<TestCase("askdjkölsm")>]
[<TestCase("")>]
let ConvertStringToInt_ReturnsMinus1 (string: string) =
    let result = Utils.convertStringToInt(string);
    Assert.AreEqual(-1, result)

[<Test>]
[<TestCase("1", 1)>]
[<TestCase("999", 999)>]
let ConvertStringToInt_ReturnsInt (string: string, int: int) =
    let result = Utils.convertStringToInt(string);
    Assert.AreEqual(int, result)
    