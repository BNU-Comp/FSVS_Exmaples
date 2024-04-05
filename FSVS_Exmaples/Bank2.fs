module Bank2

open System

(*Define an type named Account that contains an account Number string and 
balance float field. The type includes methods to Withdrawal and Deposit money 
into the account along with a Print member that displays the field values on a 
single line within the console. If the withdrawal amount is greater than the 
account balance then the transaction must be cancelled and a suitable message 
displayed.*)
type Account = 
    {
        AccountNumber: string
        mutable Balance: float
    }
    member this.Deposit amount = 
        this.Balance <- this.Balance + amount
    member this.Withdraw amount = 
        if amount > this.Balance then
            printfn "Insufficient funds"
        else
            this.Balance <- this.Balance - amount
    member this.Print = 
        printfn "Account Number: %s, Balance: %0.2f" this.AccountNumber this.Balance
//Task 2
(*Define a function named CheckAccount that implements pattern matching
to display balance is low if the balance is <10.0 and displays balance is 
OK if the balance is >= 10.0 and <= 100.0*)
let CheckAccount account =
    match account.Balance with
    | x when x < 10.0 -> printfn "Balance is low"
    | x when x >= 10.0 && x <= 100.0 -> printfn "Balance is OK"
    | _ -> printfn "Balance is high"

        
        (*Create three bank accounts and make some withdrawls and deposits to test 
        the account type and print all the results out*)
module TestAccounts =
        let run() =
            let account1 = {AccountNumber = "0001"; Balance = 0.0}
            let account2 = {AccountNumber = "0002"; Balance = 5.0}
            let account3 = {AccountNumber = "0003"; Balance = 51.0}
            let account4 = {AccountNumber = "0004"; Balance = 25.0}
            let account5 = {AccountNumber = "0004"; Balance = 99.0}
            let account6 = {AccountNumber = "0006"; Balance = 101.0}

            account1.Withdraw 50.0
            account1.Deposit 25.0
            account1.Print
            CheckAccount account1
            printfn " "
            
            account2.Deposit 100.0
            account2.Withdraw 50.0
            account2.Print
            CheckAccount account2
            printfn " "

            account3.Deposit 1000.0
            account3.Withdraw 1000.0
            account3.Print
            CheckAccount account3
            printfn " "

            account4.Deposit 150.0
            account4.Withdraw 75.0
            account4.Print
            CheckAccount account4
            printfn " "

            account5.Deposit 300.52
            account5.Withdraw 10.52
            account5.Print
            CheckAccount account5
            printfn " "

            account6.Deposit 1000000.0
            account6.Withdraw -500.0
            account6.Print
            CheckAccount account6
            printfn " "

 (**)       //task 3
            let Accounts = [account1; account2; account3; account4; account5; account6]
            // create a list of six new accounts with vaues
            //let Accounts = [{AccountNumber = "0001"; Balance = 0.0};{AccountNumber = "0001"; Balance = 0.0}]
            
            printfn "list of six Accounts "

            for account in Accounts do
                account.Print
                CheckAccount account
                printfn " "
            // Create a new list with sequence of all the accounts where the balalance is < 50.0
            let LowBalanceAccounts = 
                Seq.filter (fun account -> account.Balance < 50.0) Accounts
            printfn "Sequence of Low Balance Accounts "

            for account in LowBalanceAccounts do
                account.Print
                CheckAccount account
                printfn " "
           
           // Create a new list with sequence of all the accounts where the balalance is >= 50.0
            let HighBalanceAccounts = 
                Seq.filter (fun account -> account.Balance >= 50.0) Accounts
            printfn "Sequence of High Balance Accounts "

            for account in HighBalanceAccounts do
                account.Print
                CheckAccount account
                printfn " "

            0
            
        

        

