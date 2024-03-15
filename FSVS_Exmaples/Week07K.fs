module Week07K

open System

// Create a Customer type that has two fields: Name and Email address
type Customer = 
    {
        Name: string
        Email: string
    }
// add a method to print the customer details
    member this.Print =
        Console.WriteLine($"  {this.Name} {this.Email}")
// add a method to update the customer email
    member this.UpdateEmail newEmail =
        {this with Email = newEmail}
// create a customer called Kate with an email address
let kate = {Name="Kate"; Email="Kate@gmail.com"}
// print the customer details
kate.Print
