module Seatbooking

open System
open System.Threading

type Ticket = 
    {
        SeatNumber: int
        mutable Customer: string
        mutable Status: string
    }
    member this.Book name = 
        if this.Status = "Available" then
            this.Status <- "Booked"
            this.Customer <- name
        else
            printfn "Seat is not available"
    member this.Cancel = 
        if this.Status = "Booked" then
            this.Status <- "Available"
            this.Customer <- ""
        else
            printfn "Ticket %i is canceled and seat is available" this.SeatNumber
            printfn ""
    member this.Print = 
        printfn "Customer: %s, Seat Number: %i, Status: %s" 
                this.Customer
                this.SeatNumber 
                this.Status
        

module TestTickets = 
    let run() = 
        let ticket1 = {SeatNumber = 1; Customer = ""; Status = "Available"}
        let ticket2 = {SeatNumber = 2; Customer = ""; Status = "Available"}
        let ticket3 = {SeatNumber = 3; Customer = "Mary"; Status = "Booked"}
        let ticket4 = {SeatNumber = 4; Customer = "Daren"; Status = "Booked"}
        let ticket5 = {SeatNumber = 5; Customer = ""; Status = "Available"}
        let ticket6 = {SeatNumber = 6; Customer = ""; Status = "Available"}
       

        ticket1.Book "John"
        ticket1.Print
        ticket2.Book "Jane"
        ticket2.Print
        ticket3.Cancel
        ticket3.Print
        ticket4.Cancel
        ticket4.Print
        ticket5.Book "Jack"
        ticket5.Print
        ticket6.Cancel
        ticket6.Print
        printfn ""

        //let mutable tickets = [for n in 1..10 -> {Ticket.seat = n; Ticket.customer = ""}]
        let mutable tickets = [for n in 1..10 -> {SeatNumber = n; Customer = ""; Status = "Available"}]
        //print all tickets
        printfn "All Tickets"
        for ticket in tickets do
            ticket.Print
        printfn ""

        (* Create a function called BookSeat which will request the name of a customer
         and will book an availble seat to that customer.The function will display
         No seats available if no seats are available*)
        let rec BookSeat () =
            printfn "Enter customer name: "
            let name = Console.ReadLine()
            printfn "Enter seat number: "
            let seatNumber = int(Console.ReadLine())
            let ticket = tickets.[seatNumber - 1]
            if ticket.Status = "Available" then
                ticket.Book name
            else
                printfn "Seat is not available"

            //Example of recursion and pattern matching function
            //match tickets with
            //| [] -> printfn "No seats available"
            //| ticket::remainingTickets ->
              //  if ticket.Status = "Available" then
                    //ticket.Book name
                //else
                  //  BookSeat ()

        let thread1 = new Thread(new ThreadStart (BookSeat))
        let thread2 = new Thread(new ThreadStart (BookSeat))
        thread1.Start()
        Thread.Sleep(5000)
        thread2.Start()

        thread1.Join()
        thread2.Join()

        // Print all tickets
        printfn "All Tickets"
        for ticket in tickets do
            ticket.Print
        printfn ""
    

        0

