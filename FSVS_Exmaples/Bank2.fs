module Bank2
open System

(*
  Define a record type for a Bank Account that has an AccountNo of type
  string and a mutable Balance of type float.  Add methods to Print
  the account details, increase the balance by making a Deposite and 
  decrease the balance by marking a Withdrawal
*)
module BankAccount =
    type Account = {
        AccountNo : string
        mutable Balance : float
    }

    let printAccount (account: Account) =
        printfn "  Account No: %s, Balance: %.2f" account.AccountNo account.Balance

    let deposit (amount: float) (account: Account) =
        account.Balance <- account.Balance + amount

    let withdraw (amount: float) (account: Account) =
        account.Balance <- account.Balance - amount

    let run() =
        printfn "\n\n  Bank Account Record\n"
        let account = { AccountNo = "123456"; Balance = 1000.00 }
        printAccount account

        deposit 500.00 account
        printAccount account

        withdraw 200.00 account
        printAccount account

        0

