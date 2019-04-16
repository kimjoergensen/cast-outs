
var script = document.createElement("script")

script.src = "https://cdn.jsdelivr.net/npm/@aspnet/signalr@1.1.4/dist/browser/signalr.js"

document.head.appendChild(script)

let connection = undefined

setTimeout(() => {
    
    connection = new signalR
        .HubConnectionBuilder()
        .withUrl("/playerHub")
        .configureLogging(signalR.LogLevel.Information)
        .build()

    connection.start()
}, 2000)

setTimeout(() => {

    connection.on("update", console.log)

    connection.invoke("update", { Position: { X: 10, Y: 10, Z: 10 } })
}, 4000)