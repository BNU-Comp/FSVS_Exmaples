module Ethan
    open System
    open System.Threading
    type Ticket = {seat:int; customer:string}

    let run() =
        //Creates a list with seat numbers and customers
        let mutable tickets = [for n in 1..10 -> {Ticket.seat = n; Ticket.customer = ""}]

        //Function that displays the tickets list
        let displayTickets x = Console.WriteLine(string(x))
        List.iter displayTickets tickets

        //Two threads book a seat
        let mutable seatsFree : int = List.length tickets
        let lockobj = new Object()

        let bookSeat (name : string) = 
            lock lockobj (fun () ->
                if seatsFree > 0 then
                    seatsFree <- seatsFree - 1
                    printfn "%s: Seat Booked " name
                    tickets <- List.map (fun x -> {Ticket.seat = x.seat; Ticket.customer = name}) tickets
                    List.iter displayTickets tickets
                else
                    printfn "%s: No Available Seats" name)
            Thread.Sleep(1000)

        let thread1 = new Thread(fun () -> bookSeat "Ethan")
        thread1.Start()

        let thread2 = new Thread(fun () -> bookSeat "Bob")
        thread2.Start()

        thread1.Join()
        thread2.Join()

