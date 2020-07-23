import { Injectable, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService{
  private connection: signalR.HubConnection;

  constructor() { 
   this.connection = new signalR.HubConnectionBuilder()
    .withUrl(`${environment.apiUrl}/api/newround`)
    .build();
  }

  connectToHub() {
    this.start();
  }

  getConnection(): signalR.HubConnection {
    return this.connection;
  }

  stopConnnection() {
    this.connection.stop();
    console.log('Disconnected from SignalR hub');
  }

  private async start() {
    await this.connection.start()
      .then(_ => {
        console.log('Connected to SignalR hub');
      })
      .catch(error => {
        console.log(error);
        setTimeout(this.start, 5000);
      });
  }
}
