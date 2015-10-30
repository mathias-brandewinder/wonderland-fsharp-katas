open System.IO

let wordsPath = Path.Combine (__SOURCE_DIRECTORY__,"resources","words.txt")
let words = File.ReadAllLines wordsPath

type Word = string
let doublets (w1:Word,w2:Word) = [ "make me work" ]

#r @"packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let tests () =
    
    test <@ doublets ("head", "tail") = ["head"; "heal"; "teal"; "tell"; "tall"; "tail"] @>
    test <@ doublets ("door", "lock") = ["door"; "boor"; "book"; "look"; "lock"] @>
    test <@ doublets ("bank", "loan") = ["bank"; "bonk"; "book"; "look"; "loon"; "loan"] @>
    test <@ doublets ("wheat", "bread") = ["wheat"; "cheat"; "cheap"; "cheep"; "creep"; "creed"; "breed"; "bread"] @>
    
    test <@ doublets ("ye", "freezer") = [] @>

// run the tests
tests ()
