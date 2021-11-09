
open System


//----------------------------------------------------------
// Exercise: Create a `NonZeroInteger`  type that can only contain non-zero integers
//----------------------------------------------------------

module ConstrainedTypes =

    /// Must be <> 0
    type NonZeroInteger = private NonZeroInteger of int

    module NonZeroInteger =

        // Implement public constructor
        let create i =
            if i = 0 then
                None
            else
                Some (NonZeroInteger i)

        // Return the value
        let value (NonZeroInteger i) = i

// --------------------------------
// test NonZeroInteger
// --------------------------------

open ConstrainedTypes

// test
// NonZeroInteger 1 // uncomment for error
let nonZeroOpt0 = NonZeroInteger.create 0
let nonZeroOpt1 = NonZeroInteger.create 1

