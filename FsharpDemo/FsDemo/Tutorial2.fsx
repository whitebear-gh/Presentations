

// ---------------------------------------------------------------
//         Record types
// ---------------------------------------------------------------

module RecordTypes = 

    // definicja
    type ContactCard = 
        { Name     : string;
          Phone    : string;
          Verified : bool }
              
    let contact1 = { Name = "Alf" ; Phone = "111111111111" ; Verified = false }

    let contact2 = { contact1 with Phone = "2222222222222"; Verified = true }
           


// ---------------------------------------------------------------
//         Union types
// ---------------------------------------------------------------

module UnionTypes = 

    type Suit = 
        | Hearts 
        | Clubs 
        | Diamonds 
        | Spades

    /// Represents the rank of a playing card
    type Rank = 
        /// Represents the rank of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack
        static member GetAllRanks() = 
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]
                                   
    type Card =  { Suit: Suit; Rank: Rank }
              
    type Favorite =
    | Bourbon of string
    | Number of int


    let saySomethingAboutYourFavorite favorite =
        match favorite with
        | Number 7 -> "me too!"
        | Bourbon "Bookers" -> "me too!"
        | Bourbon b -> "I prefer Bookers to " + b
        | Number _ -> "I'm partial to 7"

    let bourbonResult = saySomethingAboutYourFavorite <| Bourbon "Maker's Mark"
    let numberResult = saySomethingAboutYourFavorite <| Number 7


// ---------------------------------------------------------------
//         Option types
// ---------------------------------------------------------------

module OptionTypes = 
    type Customer = { zipCode : decimal option }

    let someValue = Some 10
        
    someValue.IsSome 
    someValue.IsNone 
    someValue.Value 



// ---------------------------------------------------------------
//         Pattern matching
// ---------------------------------------------------------------

module PatternMatching = 
    
    type Person = {First:string; Last:string}
    let person1 = {First="john"; Last="Doe"}
    
    //types can be combined recursively in complex ways
    type Employee = 
      | Worker of Person
      | Manager of Employee list

    let jdoe = {First="John";Last="Doe"}
    let worker:Employee = Worker jdoe

    let jrambo = {First="Johny";Last="Rambo"}
    let worker2:Employee = Worker jrambo

    let manager = Manager [worker;worker2]

    /// A record for a person's first and last name
//    type Person = {     
//        First : string
//        Last  : string
//    }
//
//    /// define a discriminated union of 3 different kinds of employees
//    type Employee = 
//        | Engineer  of Person
//        | Manager   of Person * list<Employee>            // manager has list of reports
//        | Executive of Person * list<Employee> * Employee // executive also has an assistant
//
//    /// count everyone underneath the employee in the management hierarchy, including the employee
//    let rec countReports(emp : Employee) = 
//        1 + match emp with
//            | Engineer(id) -> 
//                0
//            | Manager(id, reports) -> 
//                reports |> List.sumBy countReports 
//            | Executive(id, reports, assistant) ->
//                (reports |> List.sumBy countReports) + countReports assistant
//
//
//    /// find all managers/executives named "Dave" who do not have any reports
//    let rec findDaveWithOpenPosition(emps : Employee list) =
//        emps 
//        |> List.filter(function 
//                       | Manager({First = "Dave"}, []) -> true       // [] matches the empty list
//                       | Executive({First = "Dave"}, [], _) -> true
//                       | _ -> false)                                 // '_' is a wildcard pattern that matches anything
//                                                                     // this handles the "or else" case



// ---------------------------------------------------------------
//         Units of measure
// ---------------------------------------------------------------

module UnitsOfMeasure = 

    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    [<Measure>]
    type mile =
        static member asMeter = 1600.<meter/mile>

    let d  = 50.<mile>          
    let d2 = d * mile.asMeter   

    printfn "%A = %A" d d2
    // let error = d + d2      
