module TradingGame.Card

type Card(name: string, health: int, damage :int,armor: int, cost : int,speed : int ) =
    member this.Health = health
    member this.Damage = damage
    member this.Cost = cost
    member this.Speed = speed
    member this.Name = name
    member this.Armor= armor