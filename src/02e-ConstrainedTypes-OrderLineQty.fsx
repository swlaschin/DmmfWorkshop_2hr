// =================================
// Given the definition of OrderLineQty below,
// write functions that increments and decrements it.
// =================================


module ConstrainedTypes =

    /// Must be between >= 1 and <= 100
    type OrderLineQty = private OrderLineQty of int

    module OrderLineQty =
        let create qty =
            if qty < 1 then
                None
            else if qty > 100 then
                None
            else
                Some (OrderLineQty qty)

        let maxValue =
            OrderLineQty 100

        let minValue =
            OrderLineQty 1

        /// Public function to get the data out of a OrderLineQty
        /// An "unwrapper" or "deconstructor" function
        let value (OrderLineQty qty) =
            qty


open ConstrainedTypes

let increment (olq:OrderLineQty) =
    let i1 = OrderLineQty.value olq   // i1 is an int
    let i2 = i1 + 1                   // i2 is an int
    OrderLineQty.create i2            // return an OrderLineQty here

// This is what the type signature looks like.
// Note that it MUST return an optional OrderLineQty!
// val increment :
//   olq:OrderLineQty -> OrderLineQty option

let decrement (olq:OrderLineQty) =
    let i1 = OrderLineQty.value olq
    let i2 = i1 - 1
    OrderLineQty.create i2

// This is what the type signature looks like.
// Note that it MUST return an option!
// val decrement :
//   olq:OrderLineQty -> OrderLineQty option

// ----------------------
// test the code
// ----------------------

// increment the smallest and largest values
OrderLineQty.minValue |> increment
OrderLineQty.maxValue |> increment

// decrement the smallest and largest values
OrderLineQty.minValue |> decrement
OrderLineQty.maxValue |> decrement


// =========================================
// Adding defaults
// =========================================

(*
What happens if you use the increment button on the website
and you go above 100?

Should you remove the item from the shopping cart?

Probably not. Instead, you want to "max out" at 100

You can do this using a "defaultValue" function.
It will leave a "Some" alone but it will
replace a "None" and with another value.

*)

let defaultValue aValue anOption =
    match anOption with
    | Some x -> x      // if Some, return the wrapped value
    | None -> aValue   // if None, return the default value

// usage examples
Some 1 |> Option.defaultValue 42    // 1
None   |> Option.defaultValue 42    // 42


// Example using the increment function above
// These now return a normal OrderLineQty instead of an optional one.

OrderLineQty.minValue
|> increment                           // this is a "Some"
|> defaultValue OrderLineQty.maxValue  // so the defaultValue is not used


OrderLineQty.maxValue
|> increment                           // this is a "None"
|> defaultValue OrderLineQty.maxValue  // so the defaultValue IS used


