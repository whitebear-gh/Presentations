
open System.Net
open System.IO 
open Microsoft.FSharp.Control

// ---------------------------------------------------------------
//         Async
// ---------------------------------------------------------------

let museums = ["MOMA", "http://moma.org/";
                "British Museum", "http://www.thebritishmuseum.ac.uk/";
                "Prado", "http://www.museodelprado.es/"]

let fetchAsync(nm, url : string) = async {
    printfn "Creating request for %s..." nm
    let req = WebRequest.Create(url)
    let! resp = req.AsyncGetResponse()
    printfn "Getting response stream for %s..." nm
    let stream = resp.GetResponseStream()
    printfn "Reading response for %s..." nm
    let reader = new StreamReader(stream)
    let! html = Async.AwaitTask(reader.ReadToEndAsync())
    printfn "Read %d characters for %s..." html.Length nm}

Async.Parallel [for nm, url in museums -> fetchAsync(nm, url)]
    |> Async.Ignore
    |> Async.RunSynchronously



// ---------------------------------------------------------------
//         Parallel array programming
// ---------------------------------------------------------------

module ParallelArrayProgramming = 
              
    let oneBigArray = [| 0 .. 100000 |]
    
    // do some CPU intensive computation 
    let rec computeSomeFunction x = 
        if x <= 2 then 1 
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)
       
    // Do a parallel map over a large input array
    let computeResults() = oneBigArray |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    printfn "Parallel computation results: %A" (computeResults())