module Bank3
open System

(*
  Define a class type for a Bank Account that has an AccountNo of type
  string and a mutable Balance of type float.  Add methods to Print
  the account details, increase the balance by making a Deposite and 
  decrease the balance by marking a Withdrawal providing there is enough 
  in the account.
*)
type Account(accountNo: string, balance: float) =
    let mutable accountNo = accountNo
    let mutable balance = balance

    member this.printAccount() =
        printfn "  Account No: %s, Balance: %.2f" accountNo balance

    member this.deposit(amount: float) =
        balance <- balance + amount

    member this.withdraw(amount: float) =
        if balance - amount >= 0.0 then
            balance <- balance - amount
        else
            printfn "  Insufficient funds to withdraw %.2f" amount

    member this.run() =
        printfn "\n\n  Bank Account Class\n"
        let account = Account("123456", 1000.00)
        account.printAccount()

        account.deposit(500.00)
        account.printAccount()

        account.withdraw(200.00)
        account.printAccount()

        account.withdraw(2000.00)
        account.printAccount()

        0

