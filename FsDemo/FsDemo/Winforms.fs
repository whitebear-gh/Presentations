
#light
open System.Drawing
open System.Windows.Forms
open System

// Generate random location for the ellipse
let rnd = new System.Random()
let x, y = rnd.Next(550), rnd.Next(350)

// Create the main form
let frm = new Form(ClientSize=Size(600,400))
// Add event handler to paint the ellipse
frm.Paint.Add(fun e ->
    e.Graphics.FillRectangle(Brushes.White, 0, 0, 600, 400)
    e.Graphics.FillEllipse(Brushes.DarkOliveGreen, x, y, 50, 50)  
  )
frm.Show()


let dist (x1, y1) (x2, y2) =
    Math.Sqrt(Math.Pow(x1 - x2, 2.0) + Math.Pow(y1 - y2, 2.0))
  ;;


let evtMessages =
    frm.MouseDown
      |> Event.filter (fun mi -> 
          // The distance between click location and 
          // the center of the ellipse is less than 25
          dist (float mi.X, float mi.Y) (float(x + 25), float(y + 25)) < 25.0 )
      |> Event.map (fun mi ->
          // Return message that we'll show to the user
          if (int (mi.Button &&& MouseButtons.Left) <> 0) then "Left button"
          elif (int (mi.Button &&& MouseButtons.Right) <> 0) then "Right button"
          else "Some trick!")

evtMessages
  |> Event.map (sprintf "Hey, you clicked on the ellipse.\nUsing: %s")
  |> Event.add (MessageBox.Show >> ignore)