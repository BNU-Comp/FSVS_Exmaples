module Seatbooking

open System

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


        0

