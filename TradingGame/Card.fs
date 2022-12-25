module TradingGame.Card

open TradingGame.Enums
open TradingGame.Enums.CardElementEnum

type Card(name: string, health: int, damage :int,armor: int, cost : int,speed : int, element: CardElementEnum) =
    member this.Health = health
    member this.Damage = damage
    member this.Cost = cost
    member this.Speed = speed
    member this.Name = name
    member this.Armor= armor
    member this.Element= element