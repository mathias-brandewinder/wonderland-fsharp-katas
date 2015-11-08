// See the file wonderland-number.md for detailed information.

let wonderlandNumber () = 42

let haveSameDigits (n1:int,n2:int) =
    (string n1 |> Set.ofSeq) = (string n2 |> Set.ofSeq)

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
