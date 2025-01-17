﻿module TradingGame.GameLogic.GameLogic

open TradingGame.Card
open TradingGame.Enums.WinnerEnum

let Battle (Player1Card: Card, Player2Card: Card) : WinnerTeam =

    let Player1KOTime = GameLogicUtil.CalculateRoundsTillKo(Player1Card, Player2Card)
    let Player2KOTime = GameLogicUtil.CalculateRoundsTillKo(Player2Card, Player1Card)

    if Player1KOTime > Player2KOTime then
        Player1Card.Health = GameLogicUtil.CalculateHealthLeft(Player1Card, Player2Card, Player2KOTime)
        WinnerTeam.Player1Win

    else
        Player2Card.Health = GameLogicUtil.CalculateHealthLeft(Player2Card, Player1Card, Player1KOTime)
        WinnerTeam.Player2Win

let rec PlayGameRec (deck1: List<Card>, deck2: List<Card>, deck1Pointer: int, deck2Pointer: int) =
    if (deck1Pointer = deck1.Length) then
        printfn "Player won the Game"
 
    elif (deck2Pointer = deck2.Length) then
        printfn "Computer won the Game"
    else     
        let player1Card =  deck1[deck1Pointer]
        player1Card.PrintCard()
        let player2Card =  deck2[deck2Pointer]
        player2Card.PrintCard()
        let winnerOfRound = Battle(deck1[deck1Pointer], deck2[deck2Pointer])

        match winnerOfRound with
        | WinnerTeam.Player1Win -> 
            printfn $"{player1Card.Name} won"
            PlayGameRec(deck1, deck2, deck1Pointer, deck2Pointer + 1)
        
        | WinnerTeam.Player2Win ->
            printfn $"{player2Card.Name} won"
            PlayGameRec(deck1, deck2, deck1Pointer + 1, deck2Pointer)
    

let rec PlayGame (deck1: List<Card>, deck2: List<Card>) =
    let deck1Pointer = 0
    let deck2Pointer = 0
    PlayGameRec(deck1, deck2, deck1Pointer, deck2Pointer)