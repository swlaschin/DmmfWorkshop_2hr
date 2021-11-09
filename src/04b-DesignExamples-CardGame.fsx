// ================================================
// Exercise: Model a card game
//
// ================================================

(*
The domain model is:

* A card is
    * a combination of a Suit (Heart, Spade) and a Rank (Two, Three, ... King, Ace)
    * OR a Joker
* A hand is a list of cards
* A deck is a list of cards
* A shuffled deck is also a list of cards, but different from a normal deck
* A player has a name and a hand
* A game consists of a deck and list of players

Actions:
* To deal, remove a card from a shuffled deck and put it on the table
* To pick up a card, add a card to a hand
* To shuffle, start with a normal deck and create a shuffled deck from it

Exercise:
* Define types to represent the domain
* Implement any functions that you can (look at the answer file if you get stuck)

*)


module CardGame =
    type Suit = Club | Diamond | Spade | Heart

    type Rank = Two | Three | Four | Five | Six | Seven | Eight
                | Nine | Ten | Jack | Queen | King | Ace

    type NonJokerCard = { Suit : Suit; Rank: Rank}
    type Card =
        | NonJokerCard of NonJokerCard
        | Joker

    // we should probably use wrapper types for these three types to stop them getting mixed up
    type Hand = Hand of Card list
    type Deck = Deck of Card list
    type ShuffledDeck = ShuffledDeck of Card list

    type Player = { Name : string; Hand : Hand}
    type Game = { Deck : Deck; Players : Player list}

    type Deal = ShuffledDeck -> Card option * ShuffledDeck   // what if the deck is empty?

    type PickUp = Card * Hand -> Hand
        // Question: Is it worth creating a special type for "Card * Hand" ?
        // Answer: Is it a useful concept in the domain? If so, then yes.
        //         In this case, probably not.

    type Shuffle  = Deck -> ShuffledDeck

    (*
    // Question: How do you document the rules of the game using types?
    // Answer: You can't -- you can only document the key concepts.
    //         For example, the algorithm used to shuffle cards or to score hands.
    /          Just add a comment such as "See algorithm.doc for details"
    *)


    (*
    // Question: How do you model extra behavior,
    //           such as calculating the scoring of a Hand?
    //
    // Answer: In OO you would add methods to the Card and Hand
    //         In FP we would do a "transform" to a new kind of thing,
    //         such as a CardScore type
    *)

    /// Aces High rule is used in Poker,
    /// or must be agreed at the beginning
    type AreAcesHigh = bool

    // You might want to score cards and hands.
    // For example Ace=13 Two=2
    type Score = int // no constraint -- can be large when adding up a hand

    // calculate a number for one single card
    type ScoreCard = Card * AreAcesHigh -> Score
    // calculate a number for a complete hand
    type ScoreHand = Hand * AreAcesHigh -> Score

    // An alternative approach is to pass a "scoring" function
    // that has the AreAcesHigh flag baked in.
    type ScoreHand_v2 = Hand * (Card -> Score) -> Score

