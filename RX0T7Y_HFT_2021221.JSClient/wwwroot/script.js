﻿let books = [];
let connection = null;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:31278/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookCreated", (user, message) => {
        getdata();
    });
    connection.on("BookDeleted", (user, message) => {
        getdata();
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata(){
    await fetch('http://localhost:31278/book')
        .then(x => x.json())
        .then(y => {
            books = y;
            //console.log(books);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(x => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + x.id + "</td><td>" + x.name + "</td><td>"
            + x.price + "</td><td>" + x.length + "</td><td>"+ `<button type="button" onclick="remove(${x.id})">Delete</button>`+"</td></tr>";
    });
}

function create() {
    let name = document.getElementById('bookname').value;
    let price = document.getElementById('bookprice').value;
    let length = document.getElementById('booklength').value;
    let pubid = document.getElementById('publisherid').value;
    fetch('http://localhost:31278/book', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Name: name,
                Price: price,
                Length: length,
                PublisherId: pubid
            }),
    })
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:31278/book/' + id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}