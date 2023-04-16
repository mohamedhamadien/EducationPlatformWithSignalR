// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var chatContainer = document.getElementById("chat");

function visibaleAndHideChat() {
    if (chatContainer.style.display != "none") {
        chatContainer.style.display = "none";
    } else {
        chatContainer.style.display = "block";
    }
}
