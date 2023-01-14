module TradingGame.State

open TradingGame.Card
open TradingGame.GameLogic
open Utils
open System

type State = 
    | Init
    | Error
    | PrintStack
    | PrintPlayerDeck
    | PrintComputerDeck
    | PrintAllGeneratedCards
    | EditDeck
    | Battle

type Cards = 
    { AllCards : list<Card> 
      ComputerDeck : list<Card> 
      PlayerStack : list<Card> 
      PlayerDeck : list<Card> }

let read(input: int) = 
    match input with
    | input when input = 1 -> PrintStack
    | input when input = 2 -> PrintPlayerDeck
    | input when input = 3 -> EditDeck
    | input when input = 4 -> Battle
    | input when input = 42 -> PrintComputerDeck
    | input when input = 44 -> PrintAllGeneratedCards
    | _ -> 
        printfn "---Error bei der Eingabe!---" 
        Error

let printMainMenu () = 
    printfn "Willkommen bei TradingGame!"
    printfn "Bitte wählen Sie eine aktivität aus!"
    printfn "1:\t Stack ansehen"
    printfn "2:\t Deck ansehen"
    printfn "3:\t Deck bearbeiten"
    printfn "4:\t Spielen"

let initGame () = 
    printMainMenu()
    let allCards = Card.generateListOfCards()
    let computerDeck = Card.getRandomCardsFromList(allCards, 5)
    let playerStack = Card.getRandomCardsFromList(allCards, 10)
    let playerDeck = Card.getRandomCardsFromList(playerStack, 5)
    (State.Init, { AllCards = allCards; ComputerDeck = computerDeck; PlayerStack = playerStack; PlayerDeck = playerDeck })

let printPlayerStack (cards: Cards) = 
    Card.printListOfCards(cards.PlayerStack)

let printPlayerDeck (cards: Cards) = 
    Card.printListOfCards(cards.PlayerDeck)

let printComputerDeck (cards: Cards) = 
    Card.printListOfCards(cards.ComputerDeck)

let printAllGeneratedCards (cards: Cards) = 
    Card.printListOfCards(cards.AllCards)

let editPlayerDeck (cards: Cards) =
    let allCards = cards.AllCards
    let computerDeck = cards.ComputerDeck
    let playerStack = cards.PlayerStack
    let playerDeck = Card.createNewDeckFromStackCards(playerStack)
    { AllCards = allCards; ComputerDeck = computerDeck; PlayerStack = playerStack; PlayerDeck = playerDeck }

let startBattle (cards: Cards) =
    GameLogic.PlayGame (cards.ComputerDeck, cards.PlayerDeck)

let continueClear () = 
    printfn "---Drücke Enter um Fortzufahren---" 
    Console.ReadLine()
    Console.Clear()

let evaluate (cards: Cards) (state: State) =
    match state with
    | Error -> 
        continueClear()
        printMainMenu()
        (state, cards)
    | PrintStack ->
        printPlayerStack(cards)
        continueClear()
        printMainMenu()
        (state, cards)
    | PrintPlayerDeck ->
        printPlayerDeck(cards)
        continueClear()
        printMainMenu()
        (state, cards)
    | EditDeck ->
        let newCards = editPlayerDeck(cards)
        continueClear()
        printMainMenu()
        (state, newCards)
    | Battle ->
        startBattle(cards)
        continueClear()
        printMainMenu()
        (state, cards)
    | PrintComputerDeck ->
        printComputerDeck(cards)
        continueClear()
        printMainMenu()
        (state, cards)
    | PrintAllGeneratedCards ->
        printAllGeneratedCards(cards)
        continueClear()
        printMainMenu()
        (state, cards)
    | _ -> 
        continueClear()
        printMainMenu()
        (state, cards)


let rec loop (state: State, cards: Cards) =
    Console.ReadLine()
    |> Utils.convertStringToInt
    |> read
    |> evaluate cards
    |> loop