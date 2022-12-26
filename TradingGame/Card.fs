module TradingGame.Card

open System.Security.Cryptography
open TradingGame.Enums
open TradingGame.Enums.CardElementEnum

type Card =
    class
        val mutable Health: int
        val Damage: int
        val Cost: int
        val Speed: int
        val Name: string
        val Armor: int
        val Element: CardElementEnum
        new(name: string, health: int, damage: int, armor: int, cost: int, speed: int, element: CardElementEnum) =
            { Health = health
              Cost = cost
              Speed = speed
              Name = name
              Armor = armor
              Element = element
              Damage = damage
            }

        member this.PrintCard() =
        do printfn $"Card {this.Name} Element {this.Element}| Health {this.Health} , Armor {this.Armor}, Damage {this.Damage},Speed {this.Speed}"
        

    end