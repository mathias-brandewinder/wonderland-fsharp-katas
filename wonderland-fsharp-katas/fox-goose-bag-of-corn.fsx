type Location =
    | LeftBank
    | RightBank
    | Boat

type Positions = {
    Fox:    Location
    Goose:  Location
    Corn:   Location
    You:    Location }

let Start = {
    Fox =   LeftBank
    Goose = LeftBank
    Corn =  LeftBank
    You =   LeftBank }

let riverCrossingPlan () : Positions list = 
    //failwith "Implement me!"


#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let invalidTransitions =
    [
        LeftBank,RightBank
        RightBank,LeftBank
    ]

let isValidTransition transition =
    invalidTransitions 
    |> Seq.exists ((=) transition)
    |> not


let tests () =

    let plan = riverCrossingPlan ()
    let everyone positions = 
        [ positions.You; positions.Fox; positions.Goose; positions.Corn ]

    // TODO: check that things move with you 
    // and not on their own?
    let validMove (before:Positions,after:Positions) =
        (everyone before, everyone after)
        ||> List.zip
        |> Seq.forall (isValidTransition)
        
    // "you begin with the fox, goose and corn on one side of the river"
    test <@ plan.Head = Start @>

    // "you end with the fox, goose and corn on the other side of the river"
    let final = plan |> Seq.last
    test <@ final = { Fox = RightBank ; Goose = RightBank; Corn = RightBank; You = RightBank } @>

    // "things are safe"

    let gooseIsSafe positions = 
        (positions.Goose <> positions.Fox)
        || (positions.Goose = positions.You)

    let cornIsSafe positions = 
        (positions.Corn <> positions.Goose)
        || (positions.Corn = positions.You)

    let boatIsValid positions = 
        let notYouOnBoat =
            [   positions.Goose = Boat 
                positions.Fox = Boat
                positions.Corn = Boat ]
            |> Seq.filter id
            |> Seq.length
            
        match positions.You with
        | Boat -> notYouOnBoat < 2
        | _ -> notYouOnBoat = 0

    plan
    |> List.iter (fun current ->
        
        // "the fox and the goose should never be left alone together"
        test <@ gooseIsSafe current @>
        
        // "the goose and the corn should never be left alone together"
        test <@ cornIsSafe current @>

        // "The boat can carry only you plus one other"
        test <@ boatIsValid current @>)

    // move is possible
    plan
    |> Seq.pairwise
    |> Seq.iter (fun (before,after) ->
        test <@ validMove (before, after) @>)

tests ()
