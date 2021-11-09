
let printOption (opt:Option<string>) =
    match opt with
    | Some str -> printfn "Some string =  %s" str
    | None -> printfn "No string" 


printOption "hello"
printOption null
printOption (Some "hello")
printOption (None)

type PersonalName =
    {
    FirstName: string
    MiddleInitial: string option
    LastName: string
    }

let person1 = {
    FirstName = "Alice"
    MiddleInitial = "X"
    LastName = "Adams"
}
