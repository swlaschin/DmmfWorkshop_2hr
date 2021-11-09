// =================================
// This file demonstrates how to define and construct a constrained Email type
// using OO techniques
// =================================

open System

/// Define a wrapper type with a *private* constructor.
/// Only code in the same module can use this constructor now.
type EmailAddress = private {PrivateValue: string}
    with
    /// Expose a public "factory" function
    /// to construct a value, or return an error
    static member Create(str) =
        if String.IsNullOrEmpty(str) then
            None
        else if not (str.Contains("@")) then
            None
        else
            Some {PrivateValue = str}

    /// Expose a public function
    /// to extract the wrapped value
    member this.Value = this.PrivateValue


//TODO uncomment to see the compiler error
let compileError = { EmailAddress.PrivateValue = "a@example.com" }

// create using the exposed constructor
let validEmailOpt = EmailAddress.Create "a@example.com"
let invalidEmailOpt = EmailAddress.Create "example.com"

let printWrappedValue emailOpt =
    // If we want to get the inner value out, we have to pattern match
    // the option
    match emailOpt with
    | Some (email:EmailAddress) ->
        let inner = email.Value
        printfn "The EmailAddress is valid and the wrapped value is %s" inner
    | None ->
        printfn "The value is None"

printWrappedValue validEmailOpt
printWrappedValue invalidEmailOpt

