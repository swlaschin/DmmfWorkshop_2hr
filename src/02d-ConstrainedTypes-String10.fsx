// =================================
// This file demonstrates how to define and construct constrained types
//
// =================================

open System

module ConstrainedTypes =

    /// Define a wrapper type with a *private* constructor.
    /// Only code in the same module can use this constructor now.
    type String10 = private String10 of string

    /// Define a helper module for String10 that
    /// has access to the private constructor
    module String10 =

        /// Expose a public "factory" function
        /// to construct a value, or return an error
        let create str =
            if String.IsNullOrEmpty(str) then
                None
            else if str.Length > 10 then
                None
            else
                Some (String10 str)

        /// Expose a public function
        /// to extract the wrapped value
        let value (String10 str) = str


open ConstrainedTypes

//TODO uncomment to see the compiler error
// let compileError = String10 "1234567890"

// create using the exposed constructor
let validString10Opt = String10.create "1234567890"
let invalidString10Opt = String10.create "12345678901"

let printWrappedValue emailOpt =
    // If we want to get the inner value out, we have to pattern match
    // the option
    match emailOpt with
    | Some string10 ->
        let inner = String10.value string10
        printfn "The String10 is valid and the wrapped value is %s" inner
    | None ->
        printfn "The value is None"

printWrappedValue validString10Opt
printWrappedValue invalidString10Opt



