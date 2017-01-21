// See the file magic-square.md for detailed information.

let values = [| 1.0 .. 0.5 .. 5.0 |]

type Square = float[,]

let dim = 3

let magicSquare () =
    // fix this so that the tests pass!
    let square = Array2D.init dim dim (fun row col ->
        values.[row * dim + col])
    square


#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let maxIndex = dim - 1
let indexes = [ 0 .. maxIndex ]

let row (sq:Square) i = [ for col in indexes -> sq.[i,col] ]
let col (sq:Square) i = [ for row in indexes -> sq.[row,i] ]

let sumRow (sq:Square) row =
    [ for col in indexes -> sq.[row,col] ] |> List.sum

let sumColumn (sq:Square) col =
    [ for row in indexes -> sq.[row,col] ] |> List.sum

let sumDownDiagonal (sq:Square) =
    [ for i in indexes -> sq.[i,i] ] |> List.sum

let sumUpDiagonal (sq:Square) =
    [ for i in indexes -> sq.[i, maxIndex - i] ] |> List.sum

let squareToSet (sq: Square) = 
    sq |> Seq.cast<'T> |> set

let tests () =

    let magic = magicSquare ()

    // the square should be made using only the given values
    test <@ squareToSet magic = set values @>

    // all the rows sum to the same number
    test <@ indexes |> List.map (sumRow magic) |> Set.ofList |> Set.count = 1 @>

    // all the columns sum to the same number
    test <@ indexes |> List.map (sumColumn magic) |> Set.ofList |> Set.count = 1 @>

    // all the diagonals sum to the same number
    test <@ sumDownDiagonal magic = sumUpDiagonal magic @>

// run the tests
tests ()
