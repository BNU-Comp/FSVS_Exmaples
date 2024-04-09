module Threads

open System
open System.Threading

let run() =

    let mutable available = true
    let lockobj = new Object()// object used to lock the critical section
  // Define a function to be executed by each thread
    let taskFunction (name: string) =
            for i = 1 to 5 do
                
                printfn "%s: %d" name i
                if available then
                    available <- false
                    printfn "%s Booked " name
                else
                    printfn " Is available"
                Thread.Sleep(1000) // Simulate some work being done
    // Create and start the first thread
    let thread1 = new Thread(fun () -> taskFunction "Thread 1")
    thread1.Start()
    
    
    // Create and start the second thread
    let thread2 = new Thread(fun () -> taskFunction "Thread 2")
    thread2.Start()

    


    // Wait for both threads to finish
    thread1.Join()
    thread2.Join()


    printfn "Both threads have finished."