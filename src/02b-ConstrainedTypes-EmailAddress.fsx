// =================================
// This file demonstrates how to define and construct a constrained Email type
// using FP technique
// =================================

open System

module ConstrainedTypes =

    /// Define a wrapper type with a *private* constructor.
    /// Only code in the same module can use this constructor now.
    type EmailAddress = private EmailAddress of string

    /// Define a helper module for EmailAddress that
    /// has access to the private constructor
    module EmailAddress =

        /// Expose a public "factory" function
        /// to construct a value, or return an error
        let create str =
            if String.IsNullOrEmpty(str) then
                None
            else if not (str.Contains("@")) then
                None
            else
                Some (EmailAddress str)

        /// Expose a public function
        /// to extract the wrapped value
        let value (EmailAddress str) = str


open ConstrainedTypes

//TODO uncomment to see the compiler error
// let compileError = EmailAddress "a@example.com"

// create using the exposed constructor
let validEmailOpt = EmailAddress.create "a@example.com"
let invalidEmailOpt = EmailAddress.create "example.com"

let printWrappedValue emailOpt =
    // If we want to get the inner value out, we have to pattern match
    // the option
    match emailOpt with
    | Some email ->
        let inner = EmailAddress.value email
        printfn "The EmailAddress is valid and the wrapped value is %s" inner
    | None ->
        printfn "The value is None"

printWrappedValue validEmailOpt
printWrappedValue invalidEmailOpt

