module TradingGame.Card

type Card(name: string, health: uint, damage : uint, life: uint,armor: uint, cost : uint,speed : uint ) =
    member this.Health = health
    member this.Damage = damage
    member this.Life = life
    member this.Cost = cost
    member this.Speed = speed
    member this.Name = name
    member this.Armor= armor