module Week07

open System

module patterns =
    let run() =
        let feedback grade =
            match  grade with
            | 'A' -> "Excellent"
            | 'B' -> "Very good"
            | 'C' -> "Good"
            | 'D' -> "Pass"
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
        printfn "  Customer Name: %s, Email: %s" customer.Name customer.Email

    // Function to update email address
    let updateEmail (newEmail: string) (customer: Customer) =
        customer.Email <- newEmail

// Example usage
    let run() =
        printfn "\n\n  Customer Record\n"
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
            printfn "  Person Name: %s, Email: %s" this.Name this.Email

        member this.updateEmail(newEmail: string) =
            this.Email <- newEmail

     // Example usage
    let run() =

        printfn "\n\n  Person Class\n"
        let alice = Person("Alice", "alice@example.com")
        alice.printPerson()

        alice.updateEmail("alice.new@example.com")
        alice.printPerson()
                
        0
(*
  Define a student class type with properties for their Name, Id and Grade.  
  Name and Id are strings and the grade is a single mutable character.
  Add methods to update the grade and print the student's full details.
  Then create a list of 6 students each with a variety of grades.
  Print the list of 6 students 
*)
module Students =
    type Student(name: string, id: string, grade: char) =
        let mutable _grade = grade

        member this.Name = name
        member this.Id = id
        member this.Grade
            with get() = _grade
            and set(value) = _grade <- value

        member this.Print() =
            printfn "  Student Name: %s, Id: %s, Grade: %c" this.Name this.Id this.Grade
    
    let run() =
        let students = [
            Student("Alice", "A123", 'A')
            Student("Bob", "B234", 'B')
            Student("Charlie", "C345", 'C')
            Student("David", "D456", 'D')
            Student("Eve", "E567", 'F')
            Student("Francis", "F678", 'F')
        ]

        printfn "\n\n  List of Students using simple loop\n"
        for student in students do
            student.Print()

        // Print the list of students using the iter function
        printfn "\n\n  List of Students using List iter function\n"
        List.iter (fun (student: Student) -> student.Print()) students

        
        0