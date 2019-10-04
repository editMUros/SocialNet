class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}

// userName is declared in razor page.
const username = userName;
const textInput = document.getElementById('messageText');
const whenInput = document.getElementById('when');
const chat = document.getElementById('chat');
const messagesQueue = [];

document.getElementById('submitButton').addEventListener('click', () => {
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
});

function clearInputField() {
    messagesQueue.push(textInput.value);
    textInput.value = "";
}

function sendMessage() {
    let text = messagesQueue.shift() || "";
    if (text.trim() === "") return;
    
    let when = new Date();
    let message = new Message(username, text);
    sendMessageToHub(message);
}

function addMessageToChat(message) {
    let isCurrentUserMessage = currentUserMsg;

    let container = document.createElement('div');
    let row = document.createElement('div');
    let offset = document.createElement('div');
    offset.className = isCurrentUserMessage ? 'col-md-6 offset-md-6' : 'col-md-6';
    row.className = 'row';

    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender " + isCurrentUserMessage ? "text-right text-white" : "text-left text-dark";
    sender.innerHTML = userName;
    let text = document.createElement('p');
    text.className = isCurrentUserMessage ? "text-right text-white" : "text-left text-dark";
    text.innerHTML = message.text;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-right" : "time-left";
    var currentdate = new Date();
    when.innerHTML = 
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    offset.appendChild(container);
    row.appendChild(offset);
    
    chat.appendChild(row);
    currentUserMsg = false;
}
