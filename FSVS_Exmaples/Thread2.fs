module Thread2

open System
open System.Threading

let run() =

    let mutable available = true
  // Define a function to be executed by each thread
    let threadFunction (name: string) =
        async {
            for i = 1 to 5 do
                
                printfn "%s: %d" name i
                if available then
                    available <- false
                    printfn "%s Booked " name
                else
                    printfn " Is available"
                do! Async.Sleep(1000) // Simulate some work being done
        }
    // Create and start the first thread
    let thread1 = threadFunction "Thread 1"
    Async.RunSynchronously thread1


    // Create and start the second thread
    let thread2 = threadFunction "Thread 2"
    Async.RunSynchronously thread2


    // Wait for both threads to finish
    //thread1.Join()
    //thread2.Join()


    printfn "Both threads have finished."

