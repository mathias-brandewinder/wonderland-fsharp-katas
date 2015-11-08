// See the file tiny-maze.md for detailed information.

type Cell =
    | Start
    | Exit
    | Empty
    | Wall

type Maze = Cell [,]

type Path =
    | X
    | O

type Solution = Path [,]

let solve (maze:Maze) : Solution =
    failwith "boom"


#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let tests () =

    // sample 3x3 maze
    let maze3x3 =
        [ [Start; Empty; Wall]
          [Wall;  Empty; Wall]
          [Wall;  Empty; Exit]]
        |> array2D

    // sample 3x3 maze solution
    let solution3x3 =
        [ [X; X; O]
          [O; X; O]
          [O; X; X]]
        |> array2D

    test <@ solution3x3 = solve maze3x3 @>

    // sample 4x4 maze
    let maze4x4 =
         [[Start; Empty; Empty; Wall ]
          [Wall;  Wall;  Empty; Empty]
          [Wall;  Empty; Empty; Wall ]
          [Wall;  Wall;  Empty; Exit ]]
         |> array2D

    // sample 4x4 maze solution
    let solution4x4 =
        [[X; X; X; O]
         [O; O; X; O]
         [O; O; X; O]
         [O; O; X; X]]
        |> array2D

    test <@ solution4x4 = solve maze4x4 @>


// run the tests
tests ()
