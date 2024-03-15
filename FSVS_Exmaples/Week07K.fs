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
            Console.WriteLine(" ")
            
        // add a method to update the customer email
        member this.UpdateEmail newEmail =
            {this with Email = newEmail}
    let run() =       
        // create a customer called Kate with an email address
        let kate = {Name="Kate"; Email="Kate@gmail.com"}
        let bob = {Name="Bob"; Email="Bob@gmail.com"}
        // print the customer details
        kate.Print
        bob.Print
        // update Kate email address
        let kate = kate.UpdateEmail "Kate2@gmail.com"
        // print the customer details
        kate.Print
        bob.Print


        0

module Classes = 
(* Define a class called Person that has a name of type string and an email of types string.
The Person Class must have methods to print the Person details out and to update
the Email address*)
    type Person
        (name:string, email:string) =
        member this.Name = name
        member this.Email = email
        member this.Print() =
            Console.WriteLine($" Person: {this.Name}")
            Console.WriteLine($" Email: {this.Email}")
            Console.WriteLine(" ")
        member this.UpdateEmail newEmail =
            new Person(this.Name, newEmail)
    let run() =       
        // create a customer called Kate with an email address
        let kate = new Person("Kate", "kate3@gmail.com")
        
        kate.Print()
        0