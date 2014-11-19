
// ---------------------------------------------------------------
//         
// ---------------------------------------------------------------

// ---------------------------------------------------------------
//         Values (variables) 
// ---------------------------------------------------------------
module Values = 
    let int1 = 176
    let int2 = (int1/4 + 5 - 7) * 4

    let string1 = "sample string"
    let string2 = """He said "hello world" after you did"""
    printfn "%s" string2

    let substring = string2.[0..6]
    printfn "%s" substring

    let boolean1 = true
    let boolean2 = false

    let boolean3 = not boolean1 && (boolean2 || false)

//    let int1 =123
//    int1 <-123


module Functions =
    let func1 x = x*x + 3             
    let result1 = func1 4573
    printfn "result is %d" result1

    let func2 (x:int) = 2*x*x - x/5 + 3

    let result2 = func2 (7 + 4)
    printfn "result is %d" result2

    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n-1)



module Others =

    let tuple1 = (1, 2, 3)
    let swapElems (a, b) = (b, a)
       
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A    tuple2: %A" tuple1 tuple2

    //fst snd _  _

// ---------------------------------------------------------------
//         Lists 
// ---------------------------------------------------------------

    let list1 = [ ]

    let list2 = [ 1; 2; 3 ]

    let list3 = 42 :: list2

    let numberList = [ 1 .. 1000 ]

    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    let daysList = 
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2012, month) do 
                  yield System.DateTime(2012, month, day) ]
                  
    // |> 
    let squares = 
        numberList 
        |> List.map (fun x -> x*x) 

        
// ---------------------------------------------------------------
//         Arrays
// ---------------------------------------------------------------

    let array1 = [| |]

    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    let array3 = [| 1 .. 1000 |]
//    array3.[1]

    let array4 = [| for word in array2 do
                        if word.Contains("l") then 
                            yield word |]

    let evenNumbers = Array.init 1001 (fun n -> n * 2) 

    let evenNumbersSlice = evenNumbers.[0..500]

    //mutable 
    array2.[1] <- "WORLD!"

// ---------------------------------------------------------------
//         Sequences
// ---------------------------------------------------------------
    let seq1 = Seq.empty

    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    let numbersSeq = seq { 1 .. 1000 }

    //lazy, IEnumarable 
    let evenNumbersSeq = Seq.init 1001 (fun n -> n * 2) 
    
    let rnd = System.Random()

    
    
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================
//=============================================================================================================

















// ---------------------------------------------------------------
//         Database access using type providers
// ---------------------------------------------------------------

module DatabaseAccess = 
              
    // The easiest way to access a SQL database from F# is to use F# type providers. 
    // Add references to System.Data, System.Data.Linq, and FSharp.Data.TypeProviders.dll.
    // You can use Server Explorer to build your ConnectionString. 

    (*
    #r "System.Data"
    #r "System.Data.Linq"
    #r "FSharp.Data.TypeProviders"

    open Microsoft.FSharp.Data.TypeProviders
    
    type SqlConnection = SqlDataConnection<ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=tempdb;Integrated Security=True">
    let db = SqlConnection.GetDataContext()

    let table = 
        query { for r in db.Table do
                select r }
    *)


    // You can also use SqlEntityConnection instead of SqlDataConnection, which accesses the database using Entity Framework.

    ()



// ---------------------------------------------------------------
//         OData access using type providers
// ---------------------------------------------------------------

//module OData = 
//
//    
//    open System.Data.SqlClient
//    open Microsoft.FSharp.Data.TypeProviders
//
//    // Consume demographics population and income OData service from Azure Marketplace. 
//    // For more information, see http://go.microsoft.com/fwlink/?LinkId=239712
//    type Demographics = Microsoft.FSharp.Data.TypeProviders.ODataService<ServiceUri = "https://api.datamarket.azure.com/Esri/KeyUSDemographicsTrial/">
//    let ctx = Demographics.GetDataContext()
//
//    // Sign up for a Azure Marketplace account at https://datamarket.azure.com/account/info
//    ctx.Credentials <- System.Net.NetworkCredential ("<your liveID>", "<your Azure Marketplace Key>")
//
//    let cities = query {
//        for c in ctx.demog1 do
//        where (c.StateName = "Washington")
//        } 
//
//    for c in cities do
//        printfn "%A - %A" c.GeographyId c.PerCapitaIncome2010.Value
//    
//
//    ()



#if COMPILED
module BoilerPlateForForm = 
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
