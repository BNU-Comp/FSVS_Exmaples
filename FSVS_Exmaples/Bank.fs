module Bank

open System
// Defined a record type called Account
// The record type has two fields: Name and Balance
type Account = 
    {
      Name: string
      Balance: float
    }

module Accounts = 
    let Account1 = 
        {Name = "001"; Balance = 0.0}
    
    let Account2 =
        {Name = "002"; Balance = 51.0}

    let Account3 =
        {Name = "003"; Balance = 5.0}

    printfn "Account1: %A" Account1


