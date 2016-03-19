# tiny-maze

_Ported from [@gigasquid](https://twitter.com/gigasquid)'s
[*wonderland-clojure-katas*](https://github.com/gigasquid/wonderland-clojure-katas)_

Alice found herself very tiny and wandering around Wonderland.  Even
the grass around her seemed like a maze.

![alice tiny](/images/alicetiny.gif)

This is a tiny maze solver.

A maze is represented by a 2D array

```fsharp
val maze3x3 : Cell [,] = [[Start; Empty; Wall]
                          [Wall; Empty; Wall]
                          [Wall; Empty; Exit]]
```


The goal is the get to the end of the maze.  A solved maze will have a
_X_ in the start, the path, and the end of the maze, and _O_ otherwise, like this.

```fsharp
val solution3x3 : Path [,] = [[X; X; O]
                              [O; X; O]
                              [O; X; X]]
```

## Instructions

- Clone or fork this repo
- `cd .paket`, run `paket.bootstrapper.exe` to install dependencies
- `cd .wonderland-fsharp-katas`, open [`tiny-maze.fsx`](tiny-maze.fsx) in your editor of choice
- Select and execute the whole code
- Make the tests pass!

## Solutions

Once you have your kata solution, you are welcome to submit a link to your repo to share here in this section with others.


If you haven't solved your kata yet - Don't Peek!

* https://github.com/epeicher/wonderland-fsharp-katas/blob/master/wonderland-fsharp-katas/tiny-maze.fsx

## License

Copyright (c) 2015 Mathias Brandewinder / MIT License.

Original Clojure version: Copyright © 2014 Carin Meier, distributed under the Eclipse Public License either version 1.0 or (at
your option) any later version.
