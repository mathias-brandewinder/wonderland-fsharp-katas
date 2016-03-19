# doublets

_Ported from [@gigasquid](https://twitter.com/gigasquid)'s
[*wonderland-clojure-katas*](https://github.com/gigasquid/wonderland-clojure-katas)_

This Kata comes from _Alice in Wonderland_'s author, Lewis
Carroll. He came up with this word puzzle that he named _Doublets_.

![Mad Hatter](/images/madhatter.gif)

The puzzle is to take two words of the same length and find a way of linking the
first word to the second word by only changing one letter at a time.  At the end of the transformation,
there will be a collections of words that show the beginning word being changed
into the ending word, one letter at a time.  All the _word links_ must be in Lewis Carroll's own words:

```
... it is de rigueur that the links should be English words, such as might be used in good society.
```

Also the _word links_ should be words that are found in the dictionary.  No proper nouns.

Here are some examples.

The Doublet of DOOR to LOCK is:

```
door
boor
book
look
lock
```

The Doublet of BANK to LOAN is:

```
bank
bonk
book
look
loon
loan
```

The Doublet of WHEAT into BREAD is:

```
wheat
cheat
cheap
cheep
creep
creed
breed
bread
```



## Instructions

- Clone or fork this repo
- `cd .paket`, run first `paket.bootstrapper.exe`, then `paket.exe install` to install the dependencies
- `cd .wonderland-fsharp-katas`, open [`doublets.fsx`](doublets.fsx) in your editor of choice
- Select and execute the whole code
- Make the tests pass!

A sample dictionary has been included in [`resources/words.txt`](resources/words.txt) with a few words to get things going.  After you solve the kata, you might want to try a bigger dictionary to discover more exciting doublets.

## Hints

This kata is a bit tricky.  You might want to start off with a really small dictionary, (like just the word link solutions) and make it pass from there.

Also don't be shy looking for other libraries or tools to help you.


## Solutions

Once you have your kata solution, you are welcome to submit a link to your repo to share here in this section with others.

If you haven't solved your kata yet - Don't Peek!

* https://github.com/epeicher/wonderland-fsharp-katas/blob/master/wonderland-fsharp-katas/doublets.fsx

## License

Copyright (c) 2015 Mathias Brandewinder / MIT License.

Original Clojure version: Copyright © 2014 Carin Meier, distributed under the Eclipse Public License either version 1.0 or (at
your option) any later version.
