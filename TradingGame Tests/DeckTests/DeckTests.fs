module TradingGame_Tests.DeckTests.DeckTests

open NUnit.Framework
open TradingGame.Card
open TradingGame.Enums.CardElementEnum

let StackOfCards: list<Card> = [Card("1", 1, 100, 10, 3, 1, 3, CardElementEnum.Fire); 
                                Card("2", 2, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("3", 3, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("4", 4, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("5", 5, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("6", 6, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("7", 7, 100, 10, 3, 1, 3, CardElementEnum.Fire);
                                Card("8", 8, 100, 10, 3, 1, 3, CardElementEnum.Fire);]

let Card: list<Card> = [Card("1", 1, 100, 10, 3, 1, 3, CardElementEnum.Fire)]

[<Test>]
let GenerateNewListOfCards () =
    let result = TradingGame.Card.generateListOfCards();
    Assert.AreEqual(100, result.Length)
    
[<Test>]
let GetRandomCardsFromList () = 
    let result = getRandomCardsFromList(StackOfCards, 2)
    Assert.AreEqual(2, result.Length)
    
[<Test>]
let CountSpecificCards () = 
    let result = countSpecificCards (StackOfCards) (Card)
    Assert.AreEqual(1, result)
    