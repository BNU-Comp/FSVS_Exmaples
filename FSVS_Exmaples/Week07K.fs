module Week07K

open System

module Customer =
    // Define a record type called Customer and make the email mutable
    type Customer = 
        {
            Name: string
            mutable Email: string
        }
        // add a method to print the customer details
        member this.Print =
            Console.WriteLine($" Customer: {this.Name}")
            Console.WriteLine($" Email: {this.Email}")
        // add a method to update the customer email
        member this.UpdateEmail newEmail =
            {this with Email = newEmail}
    let run() =       
        // create a customer called Kate with an email address
        let kate = {Name="Kate"; Email="Kate@gmail.com"}
        // print the customer details
        kate.Print
        // update Kate email address
        let kate = kate.UpdateEmail "Kate2@gmail.com"
        // print the customer details
        kate.Print


        0


