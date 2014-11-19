
// ---------------------------------------------------------------
//         Recursive functions
// ---------------------------------------------------------------

// ---------------------------------------------------------------
//         Tail reccurence 
// ---------------------------------------------------------------

module TailReccurence =
    let rec factorial x =
        if x <= 1 then 
            1
        else 
            // Recurse
            let resultOfRecusion = factorial (x - 1)
            let result = x * resultOfRecusion
            result


    let tailfactorial x = 
        let rec tailRecursiveFactorial x acc =
            if x <= 1 then 
                acc
            else 
                tailRecursiveFactorial (x - 1) (acc * x)
        tailRecursiveFactorial x 1

    let rec sum = function
        | [] -> 0
        | x::xs -> x + sum xs

    let rec tailsum acc = function
        | [] -> acc
        | x::xs -> tailsum (acc + x) xs
// ---------------------------------------------------------------
//         residual functions
// ---------------------------------------------------------------

module ResidualFunctions = 
    let add x =
        (fun y -> x + y)

    let simpleResult = add 2 4
    

    let addTen = add 10
    let fancyResult = addTen 14

