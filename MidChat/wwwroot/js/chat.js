const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .build(); 