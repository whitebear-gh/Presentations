
open System.IO
open System.Net
open System.Drawing
open System.Threading
open FSharp.Data
open FSharp.Charting

let getHttp (url: string) =
    let req = System.Net.WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html
 

 // JSON
type Bitstamp = JsonProvider<""" {"high": "844.00", "last": "714.33", "timestamp": "1386459953", "bid": "713.10", "volume": "81293.11654151", "low": "542.38", "ask": "713.88"} """>
 
let currentPrice() = 
    let tickerJson = getHttp "https://www.bitstamp.net/api/ticker/"
    let ticker = Bitstamp.Parse(tickerJson)
    ticker.Last
 

let price = currentPrice()

printf "%f\n" price

#if DEBUG
System.Console.ReadKey(true) |> ignore 
#endif