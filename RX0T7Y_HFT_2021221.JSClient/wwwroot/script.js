let books = [];
let connection = null;

let bookIdToUpdate = -1;

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
    connection.on("BookUpdated", (user, message) => {
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
            + x.price + "</td><td>" + x.length + "</td><td>" +
        `<button type="button" onclick="remove(${x.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${x.id})">Update</button>`+
            "</td></tr>";
    });
}

function showupdate(id) {
    document.getElementById('booknametoupdate').value = books.find(t => t['id'] == id)['name'];
    document.getElementById('bookpricetoupdate').value = books.find(t => t['id'] == id)['price'];
    document.getElementById('booklengthtoupdate').value = books.find(t => t['id'] == id)['length'];
    document.getElementById('publisheridtoupdate').value = books.find(t => t['id'] == id)['publisherId'];

    document.getElementById('updateformdiv').style.display = 'flex';
    bookIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('booknametoupdate').value;
    let price = document.getElementById('bookpricetoupdate').value;
    let length = document.getElementById('booklengthtoupdate').value;
    let pubid = document.getElementById('publisheridtoupdate').value;
    fetch('http://localhost:31278/book', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                Id: bookIdToUpdate,
                Name: name,
                Price: price,
                Length: length,
                PublisherId: pubid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
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