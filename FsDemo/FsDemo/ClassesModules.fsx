


// ---------------------------------------------------------------
//         Classes
// ---------------------------------------------------------------

module DefiningClasses = 

    type Vector2D(dx : float, dy : float) = 
        //field
        let length = sqrt (dx*dx + dy*dy)

        //properties
        member this.DX = dx  

        member this.DY = dy

        member this.Length = length

        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
    
    //statics
    let vector1 = Vector2D(3.0, 4.0)

 
    
///  IDisposable
type ReadFile() =

    let file = new System.IO.StreamReader("readme.txt")


    member this.ReadLine() = file.ReadLine()

    // this class's implementation of IDisposable members
    interface System.IDisposable with    
        member this.Dispose() = file.Close()


// ---------------------------------------------------------------
//         Generic classes
// ---------------------------------------------------------------

module DefiningGenericClasses = 
    
    
    type StateTracker<'T>(initialElement: 'T) = 

        let mutable states = [ initialElement ]

        member this.UpdateState newState = 
            states <- newState :: states  

        member this.History = states

        member this.Current = states.Head

    /// instancja typu int 
    let tracker = StateTracker 10

    tracker.UpdateState 17




