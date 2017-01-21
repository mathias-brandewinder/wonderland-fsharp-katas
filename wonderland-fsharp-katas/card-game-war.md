# card-game-war

_Ported from [@gigasquid](https://twitter.com/gigasquid)'s
[*wonderland-clojure-katas*](https://github.com/gigasquid/wonderland-clojure-katas)_

This kata is a version of the classic card game [War](http://en.wikipedia.org/wiki/War_%28card_game%29).

![Cards Painting](/images/cardspainting.gif)


The rules of this card game are quite simple.

- There are two players.
- The cards are all dealt equally to each player.
- Each round, player 1 lays a card down face up at the same time that
  player 2 lays a card down face up.  Whoever has the highest value
  card, wins both round and takes both cards.
- The winning cards are added to the bottom of the winners deck.
- Aces are high.
- If both cards are of equal value, then the winner is decided upon by
  the highest suit.  The suits ranks in order of ascending value are
  spades, clubs, diamonds, and hearts.
- The player that runs out of cards loses.


## Instructions

- Clone or fork this repo
- `cd .paket`, run first `paket.bootstrapper.exe`, then `paket.exe install` to install the dependencies
- `cd .wonderland-fsharp-katas`, open [`card-game-war.fsx`](card-game-war.fsx) in your editor of choice
- Select and execute the whole code
- In this kata, you will be prompted to fill in your own tests.
- Make the tests pass!

## Solutions

Once you have your kata solution, you are welcome to submit a link to your repo to share here in this section with others.


If you haven't solved your kata yet - Don't Peek!

* https://github.com/epeicher/wonderland-fsharp-katas/blob/master/wonderland-fsharp-katas/card-game-war.fsx
* https://github.com/strmpnk/wonderland-fsharp-katas/blob/solutions/wonderland-fsharp-katas/card-game-war.fsx
* https://github.com/nestordemeure/wonderland-fsharp-katas/blob/master/wonderland-fsharp-katas/card-game-war.fsx

## License

Copyright (c) 2015 Mathias Brandewinder / MIT License.

Original Clojure version: Copyright © 2014 Carin Meier, distributed under the Eclipse Public License either version 1.0 or (at
your option) any later version.
