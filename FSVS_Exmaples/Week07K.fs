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

module Students =
    (* Def a function that will pattern match a Student Grade with a phrase such
    Excellent or for grade A*)
    let GradePhrase grade =
        match grade with
        | 'A' -> "Excellent"
        | 'B' -> "Very Good"
        | 'C' -> "Good"
        | 'D' -> "Pass"
        | 'E' -> "Fail"
        | 'F' -> "Refer"
        | _ -> "Invalid Grade"

    (*Define a record type called Student which has a name of type string, 
    an Id of type string and a mutable grade of type char.The record should also have a method for
    printing the Student details*)
    type Student = 
        {
            Name: string
            Id: string
            mutable Grade: char
        }
        member this.Print =
            Console.WriteLine($" Student: {this.Name}")
            Console.WriteLine($" Id: {this.Id}")
            Console.WriteLine($" Grade: {this.Grade}")
            Console.WriteLine($" Grade Phrase: {GradePhrase this.Grade}")
            Console.WriteLine(" ")
        member this.UpdateGrade newGrade =
            {this with Grade = newGrade}
       let run() =
       // Create a list of six Students
           let students = [
                {Name="Kate"; Id="001"; Grade='A'}
                {Name="Bob"; Id="002"; Grade='B'}
                {Name="James"; Id="003"; Grade='C'}
                {Name="Mary"; Id="004"; Grade='D'}
                {Name="John"; Id="005"; Grade='E'}
                {Name="Jane"; Id="006"; Grade='F'}
           ]
           // Print the details of each student
           for student in students do
                student.Print
            // Print the list of students using the List iter function
           printfn "\n\n  List of Students using List iter function\n"
           List.iter (fun (student: Student) -> student.Print) students
        
           let passStudents = List.filter (fun (student: Student) -> student.Grade <> 'F') students
           let referStudents = List.filter (fun (student: Student) -> student.Grade = 'F') students
        
           printfn "\n  Passed Students"
           passStudents |> List.iter (fun (student: Student) -> student.Print)

           printfn "\n  Referred Students"
           referStudents |> List.iter (fun (student: Student) -> student.Print)
           0

     