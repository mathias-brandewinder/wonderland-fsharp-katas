# fox-goose-bag-of-corn

_Ported from [@gigasquid](https://twitter.com/gigasquid)'s
[*wonderland-clojure-katas*](https://github.com/gigasquid/wonderland-clojure-katas)_

One of Lewis Carroll's favorite puzzles to ask children was the one
about the _Fox, Goose, and Bag of Corn_.  It has to do with getting
them all safely across a river.

![alice swimming](/images/storytelling.gif)


The rules for this puzzle are:

- You must get the fox, goose, and bag of corn safely across the other side of the river
- You can only carry 1 item on the boat across with you.
- The fox cannot be left alone with the goose, (or it will be eaten).
- The goose cannot be left alone with the corn, (or it will be eaten).

The starting position is you, the fox, the goose, and corn on the left bank of the river. The boat is empty. The other river bank is empty.

```fsharp
let Start = {
    Fox =   LeftBank
    Goose = LeftBank
    Corn =  LeftBank
    You =   LeftBank }
```

You could take the corn on the boat with you

```fsharp
let Next = { Start with You = Boat; Corn = Boat; }
```

But then the fox would eat the goose!

The goal is to have the plan in steps so that all make it safely to the other side

```fsharp
let Final = {
    Fox =   RightBank
    Goose = RightBank
    Corn =  RightBank
    You =   RightBank }
```

## Instructions

- Clone or fork this repo
- `cd .paket`, run first `paket.bootstrapper.exe`, then `paket.exe install` to install the dependencies
- `cd .wonderland-fsharp-katas`, open [`fox-goose-bag-of-corn.fsx`](fox-goose-bag-of-corn.fsx) in your editor of choice
- Select and execute the whole code
- Make the tests pass!

## Solutions

Once you have your kata solution, you are welcome to submit a link to your repo to share here in this section with others.

If you haven't solved your kata yet - Don't Peek!

## License

Copyright (c) 2015 Mathias Brandewinder / MIT License.

Original Clojure version: Copyright © 2014 Carin Meier, distributed under the Eclipse Public License either version 1.0 or (at
your option) any later version.
