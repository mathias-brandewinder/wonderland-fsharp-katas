type Passenger =
    | Fox
    | Goose
    | Corn
    | You

type World = { 
    LeftBank  : Passenger Set
    RightBank : Passenger Set
    Boat      : Passenger Set }

let Start = { 
    LeftBank = set []
    RightBank = set []
    Boat = set [] }

let riverCrossingPlan () : World list = failwith "Implement me!"         


#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let tests () =

    let plan = riverCrossingPlan ()

    // TODO: add validation of moves
    let validMove (before:World,after:World) = true

    // "you begin with the fox, goose and corn on one side of the river"
    test <@ plan.Head = { LeftBank = set [ You; Fox; Goose; Corn ] ; RightBank = Set.empty; Boat = Set.empty } @>

    // "you end with the fox, goose and corn on one side of the river"
    let final = plan |> Seq.last
    test <@ final = { LeftBank = Set.empty ; RightBank = set [ You; Fox; Goose; Corn ]; Boat = Set.empty } @>

    // "things are safe"

    let left w (x,y) = w.LeftBank.Contains x && w.LeftBank.Contains y
    let right w (x,y) = w.RightBank.Contains x && w.RightBank.Contains y
    let boat w = w.Boat.Count = 1 || (w.Boat.Count = 2 && w.Boat.Contains You)

    plan
    |> List.iter (fun world ->
        let l = left world
        let r = right world
        // "the fox and the goose should never be left alone together"
        test <@ l (Fox,Goose) || r (Fox,Goose) |> not @>                
        // "the goose and the corn should never be left alone together"
        test <@ l (Goose,Corn) || r (Goose,Corn) |> not @>
        // "The boat can carry only you plus one other"
        test <@ boat world @>)

    // move is possible
    plan
    |> Seq.pairwise
    |> Seq.iter (fun (before,after) ->
        test <@ validMove (before, after) @>)

tests ()
