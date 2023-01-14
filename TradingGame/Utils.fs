module Utils

let convertStringToInt(string: string) =
    match System.Int32.TryParse string with
    | true, int -> int
    | _ -> -1
