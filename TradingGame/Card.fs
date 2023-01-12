module TradingGame.Card

open TradingGame.Enums.CardElementEnum
open System

type Card =
    class
        val mutable Health: int
        val Id: int
        val Damage: int
        val Cost: int
        val Speed: int
        val Name: string
        val Armor: int
        val Element: CardElementEnum
        new(name: string, id: int, health: int, damage: int, armor: int, cost: int, speed: int, element: CardElementEnum) =
            { Health = health
              Id = id
              Cost = cost
              Speed = speed
              Name = name
              Armor = armor
              Element = element
              Damage = damage
            }

        member this.PrintCard() =
        do 
            printf $"Id: {this.Id}\t| Card '{this.Name}' {new String(' ', 35 - this.Name.Length)} Element {this.Element} {new String(' ', 5 - this.Element.ToString().Length)}| "
            printfn $"""Health {String.Format("{0:D2}", this.Health)}, Armor {String.Format("{0:D2}", this.Armor)}, Damage {String.Format("{0:D2}", this.Damage)}, Speed {String.Format("{0:D2}", this.Speed)}"""        

    end

let random = new System.Random()

let name = ["Albert Tross";"Harry Bo";"Heidi Kraut";"Hein Blöd";"Hella Wahnsinn";"Olle Schleuder";"Peter Petersilie";"Herta Wurst";"Axel Haar";"Jo Ghurt";"Johannes Kraut";"Rainer Zufall";"Dick Tator";"Rosa Hirn";"Ernst Haft";"Lee Kör";"Klaus Trophobie";"Sunny Täter";"Klara Fall";"Timo Tee";"Wilma Streit"]

let nameTitel = ["";"der/die Dünne";"der/die Junge";"der/die Alte";"der/die Salizige";"der/die Taktvolle";"der/die Rohe";"";"der/die Starke";"der/die Schwache";"der/die Mutige";"der/die Elastische";"der/die Moderne";"der/die Schnelle";"der/die Langsame";"der/die Gerechte";"";"";"";"";"";"";"";"";"";"";""]

let generateListOfCards () : list<Card> = 
    [for i in 1 .. 100 do yield (Card(
        $"{name[random.Next(1,100) % name.Length]} {nameTitel[random.Next(1,100) % nameTitel.Length]}".Trim(),
        i, 
        random.Next(1,100), 
        random.Next(1,100), 
        random.Next(1,100), 
        random.Next(1,100), 
        random.Next(1,100), 
        LanguagePrimitives.EnumOfValue (random.Next(1,100) % 4)))]

let getRandomCardsFromList (listOfCards: list<Card>, amount: int) : list<Card> =
    [for _ in 1 .. amount do yield (listOfCards[random.Next(1, Int32.MaxValue) % listOfCards.Length])]  

let printListOfCards (deck: list<Card>) = deck |> List.sortBy(fun x -> x.Id ) |> Seq.iter (fun i -> i.PrintCard())

let filterStack (stack: list<Card>, cardIds: int): list<Card> = stack |> List.filter(fun x -> x.Id = cardIds) |> List.distinct

let rec searchCard (stack: list<Card>) (newDeck: list<Card>) (clearPrint: bool) : list<Card> = 
    if clearPrint then
        Console.Clear()
        printfn "Stack: "
        printListOfCards stack
        printfn "------------------------------------------------------"
        printfn "Deck: "
        printListOfCards newDeck
        printfn ""
        printfn $"Sie können noch {5-newDeck.Length} Karten auswählen"
        printfn "Bitte geben Sie die gewünschte Karten Id ein"

    let searchId = Console.ReadLine() |> int
    let result = filterStack (stack, searchId)
    if result.Length = 0 then
        printfn $"Keine Karte mit Id '{searchId}' gefunden"
        searchCard stack newDeck false
    else
        let stackCardCount = stack |> List.where(fun x -> x.Id = result.Head.Id)
        let deckCardCount = newDeck |> List.where(fun x -> x.Id = result.Head.Id)
        if deckCardCount.Length = stackCardCount.Length then
            printfn $"Karte mit Id '{searchId}' zu oft im Deck"
            searchCard stack newDeck false
        elif newDeck.Length < 4 then
            let decksss = List.append newDeck result
            searchCard stack (List.append newDeck result) true
        else
            List.append newDeck result

let createNewDeckFromStackCards (stack: list<Card>) : list<Card> = 
    let newDeck = List.Empty
    searchCard stack newDeck true
