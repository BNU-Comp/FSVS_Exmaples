module Bank4

type Account = 
    {
        accountNo: string; 
        mutable balance: float 
    }

    member this.printAccount =
        printfn "  Account No: %s, Balance: %.2f" this.accountNo this.balance

module TestAccount =
    let run() =
        printfn "\n\n  Bank Account Class\n"
        let account = { accountNo = "123456"; balance = 1000.00 }
        account.printAccount

        account.balance <- account.balance + 500.00
        account.printAccount

        account.balance <- account.balance - 200.00
        account.printAccount

        account.balance <- account.balance - 2000.00
        account.printAccount

        0