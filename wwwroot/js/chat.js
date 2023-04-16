"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;


connection.on("ReceiveMessage", function (user, message,time) {
    var usermail = document.getElementById("userInputName").value.split('@');
    var curruser = usermail[0];

    var x = "outgoing";
    if (curruser == user) {

        x = "outgoing"
    }
    else {
        x = "coming"
    }
   
    var divChat = ` <div class="message ${x}">
        <h5> ${user}   : <span style="font-size :9px !important;">${time}</span></h5>
            <p>${message}</p>
                     </div>
  `;

    document.getElementById("messagesList").innerHTML += divChat;
 
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var url1 = window.location.pathname.split('/');
    var nurl = url1[1];
    connection.invoke("SendMessage", nurl, message).catch(function (err) {
      return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("closebtn").addEventListener("click", function (event) {
    document.getElementById("messagesList").remove ;
    var x = document.getElementById("messagesList").value;
    event.preventDefault();
});

document.getElementById("showButton").addEventListener("click", function (event) {
    document.getElementById("showButton").id = "";
    var url1 = window.location.pathname.split('/');
    var nurl = url1[1];
    connection.invoke("ShowChat", nurl).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
