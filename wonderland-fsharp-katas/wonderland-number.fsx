// See the file wonderland-number.md for detailed information.

let haveSameDigits (n1:int,n2:int) =
    (string n1 |> Set.ofSeq) = (string n2 |> Set.ofSeq)

let allGood (n:int) =
    let multipliers = [ 2 .. 6 ]
    (string n).Length = 6
    && multipliers |> List.fold (fun ok mult -> ok && haveSameDigits (n, (n * mult))) true
    
// brute-force, baby, brute-force
let wonderlandNumber () = 
    let rec search x =
        if allGood x 
        then x
        else search (x + 1)
    search 100000

#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let tests () =

    let wonderNum = wonderlandNumber ()

    test <@ (string wonderNum).Length = 6 @>

    test <@ haveSameDigits (wonderNum, 2 * wonderNum) @>
    test <@ haveSameDigits (wonderNum, 3 * wonderNum) @>
    test <@ haveSameDigits (wonderNum, 4 * wonderNum) @>
    test <@ haveSameDigits (wonderNum, 5 * wonderNum) @>
    test <@ haveSameDigits (wonderNum, 6 * wonderNum) @>

// run the tests
tests ()
