// See the file card-game.md for detailed information.

// feel free to use these cards or use your own data structure

type Suit =
    | Spade
    | Club
    | Diamond
    | Heart

type Rank =
    | Value of int
    | Jack
    | Queen
    | King
    | Ace

type Card = Suit * Rank

let playRound (card1:Card,card2:Card) =
    failwith "not implemented: winning card"

let playGame (hand1:Card list, hand2:Card list) =
    failwith "not implemented: game winner"

(*
let suits = [ Spade; Club; Diamond; Heart ]
let heads = [ Jack; Queen; King; Ace ]

let ranks =
    [   for v in 2 .. 10 -> Value v
        for head in heads -> head
    ]

let deck = seq {
    for suit in suits do
        for rank in ranks -> suit,rank }
*)

// fill in tests for your game
let tests () =

    // playRound
    printfn "TODO: the highest rank wins the cards in the round"
    printfn "TODO: queens are higher rank than jacks"
    printfn "TODO: kings are higher rank than queens"
    printfn "TODO: aces are higher rank than kings"
    printfn "TODO: if the ranks are equal, clubs beat spades"
    printfn "TODO: if the ranks are equal, diamonds beat clubs"
    printfn "TODO: if the ranks are equal, hearts beat diamonds"

    // playGame
    printfn "TODO: the player loses when they run out of cards"

// run the tests
tests ()
