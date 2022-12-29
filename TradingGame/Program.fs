module TradingGame.Main

open System
open TradingGame.Card
open TradingGame.Enums.CardElementEnum

[<EntryPoint>]
let main argv =

    let initGame = State.initGame()

    State.loop initGame

    0 // return an integer exit code