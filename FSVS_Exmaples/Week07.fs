module Week07

open System

module patterns =
    let run() =
        let feedback grade =
            match  grade with
            | 'A' -> "Excellent"
            | 'B' -> "Very good"
            | 'C' -> "Good"
            | _ -> "Fail"

        Console.Write("  Your grade is ")
        Console.WriteLine(feedback 'B')
        Console.WriteLine("  ")
(*
  Define a record type for a customer with mutable fields for their 
  Name and Email address.  Then define a function to print the customer's 
  details and another function to update the email address.
  Then create a record for a customer and display the fields.
*)
module Records =
    type Customer = {
        Name : string
        mutable Email : string
    }

    // Function to print the person
    let printCustomer (customer: Customer) =
        printfn "Customer Name: %s, Email: %s" customer.Name customer.Email

    // Function to update email address
    let updateEmail (newEmail: string) (customer: Customer) =
        customer.Email <- newEmail

// Example usage
    let run() =
        let alice = { Name = "Alice"; Email = "alice@gmail.com"}
        printCustomer alice
        
        0
(* 
Define a person class type with propertie for their Name and Email address.  
 and methods to update the email address and print the person's details.
 Then create a record for a person and display the fields.
 *)
module Classes =
    type Person(name: string, email: string) =
        let _name = name
        let mutable _email = email

        member this.Name
            with get() = _name

        member this.Email
            with get() = _email
            and set(value) = _email <- value

        member this.printPerson() =
            printfn "Person Name: %s, Email: %s" this.Name this.Email

        member this.updateEmail(newEmail: string) =
            this.Email <- newEmail

     // Example usage
     let run() =
        let alice = Person("Alice", "alice@example.com")
        alice.printPerson()

        alice.updateEmail("alice.new@example.com")
        alice.printPerson()
                
        0
