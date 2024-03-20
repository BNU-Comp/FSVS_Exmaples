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

