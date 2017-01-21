open System

// See the file alphabet-cipher.md for detailed information.

let substitution = @"
   ABCDEFGHIJKLMNOPQRSTUVWXYZ
 A abcdefghijklmnopqrstuvwxyz
 B bcdefghijklmnopqrstuvwxyza
 C cdefghijklmnopqrstuvwxyzab
 D defghijklmnopqrstuvwxyzabc
 E efghijklmnopqrstuvwxyzabcd
 F fghijklmnopqrstuvwxyzabcde
 G ghijklmnopqrstuvwxyzabcdef
 H hijklmnopqrstuvwxyzabcdefg
 I ijklmnopqrstuvwxyzabcdefgh
 J jklmnopqrstuvwxyzabcdefghi
 K klmnopqrstuvwxyzabcdefghij
 L lmnopqrstuvwxyzabcdefghijk
 M mnopqrstuvwxyzabcdefghijkl
 N nopqrstuvwxyzabcdefghijklm
 O opqrstuvwxyzabcdefghijklmn
 P pqrstuvwxyzabcdefghijklmno
 Q qrstuvwxyzabcdefghijklmnop
 R rstuvwxyzabcdefghijklmnopq
 S stuvwxyzabcdefghijklmnopqr
 T tuvwxyzabcdefghijklmnopqrs
 U uvwxyzabcdefghijklmnopqrst
 V vwxyzabcdefghijklmnopqrstu
 W wxyzabcdefghijklmnopqrstuv
 X xyzabcdefghijklmnopqrstuvw
 Y yzabcdefghijklmnopqrstuvwx
 Z zabcdefghijklmnopqrstuvwxy
"

type Message = string
type Keyword = string

let values =
    substitution.Split [|'\n'|]
    |> Array.filter (fun v -> not (System.String.IsNullOrEmpty(v)))
    |> Array.skip 1
    |> Array.map (fun v -> 
            let tmp = v.Split [|' '|] |> Array.skip 1
            tmp.[0].[0], tmp.[1])
    |> dict


let generateKeyOnMessage (key:Keyword) (message:Message) =
    let longKey = 
        if key.Length >= message.Length then key.Substring(0, message.Length)
        else 
            let count = message.Length / key.Length
            let rest = message.Length - count * key.Length
            let tmp = List.replicate count key 
                        |> System.String.Concat
            tmp + key.Substring(0, rest)                                  
    longKey

let charToDigit (c:char) = 
    (int (c |> System.Char.ToUpper)) - (int 'A')

let lookupLetter (row,column) =
    let tmp = values.[row |> System.Char.ToUpper]
    tmp.[charToDigit column]

let encode (key:Keyword) (message:Message) : Message =
    let longKey = generateKeyOnMessage key message
    longKey
        |> Seq.mapi (fun i v -> message.[i], v)
        |> Seq.map lookupLetter
        |> Seq.toArray |> System.String

let lookupDecode (key:char) (toFind:char) =
    let pos = charToDigit key
    values.Keys
          |> Seq.find (fun k -> values.[k].[pos] = toFind)

let decode (key:Keyword) (message:Message) : Message =
    let longKey = generateKeyOnMessage key message
    longKey
        |> Seq.mapi (fun i v -> lookupDecode v message.[i] |> System.Char.ToLower)
        |> Seq.toArray |> System.String

let digitToChar d = 
    char ((int 'A') + d)

let lookupDecipher (key:char) (value:char) =
    let line = values.[key |> System.Char.ToUpper]
    line
    |> Seq.findIndex (fun c -> c = value)
    |> digitToChar

let detectRepeating (s:string) = 
    let regex = Text.RegularExpressions.Regex("(.+?)\\1+")
    if regex.Match(s).Groups.Count > 1 then 
        regex.Match(s).Groups.[1].Value
    else
        s

let decipher (cipher:Message) (message:Message) : Keyword =
    message
    |> Seq.mapi (fun i v -> lookupDecipher v cipher.[i] |> System.Char.ToLower)
    |> Seq.toArray |> System.String
    |> detectRepeating

#r @"../packages/Unquote/lib/net45/Unquote.dll"
open Swensen.Unquote

let tests () =

    // verify encoding
    test <@ encode "vigilance" "meetmeontuesdayeveningatseven" = "hmkbxebpxpmyllyrxiiqtoltfgzzv" @>
    test <@ encode "scones" "meetmebythetree" = "egsgqwtahuiljgs" @>

    // verify decoding
    test <@ decode "vigilance" "hmkbxebpxpmyllyrxiiqtoltfgzzv" = "meetmeontuesdayeveningatseven" @>
    test <@ decode "scones" "egsgqwtahuiljgs" = "meetmebythetree" @>

    // verify decyphering
    test <@ decipher "opkyfipmfmwcvqoklyhxywgeecpvhelzg" "thequickbrownfoxjumpsoveralazydog" = "vigilance" @>
    test <@ decipher "hcqxqqtqljmlzhwiivgbsapaiwcenmyu" "packmyboxwithfivedozenliquorjugs" = "scones" @>

// run the tests
tests ()