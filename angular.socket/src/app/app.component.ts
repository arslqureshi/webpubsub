import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WebsocketService } from './websocket.service';
import { HttpClientModule } from '@angular/common/http';
import { WebPubSubClient } from '@azure/web-pubsub-client';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  private pubSubClient?: WebPubSubClient;
  constructor(private websocketService: WebsocketService) {}

  async ngOnInit() {
    this.pubSubClient = await this.websocketService.connect();
  }

  sendMessage() {
    this.pubSubClient?.sendEvent(
      'http://127.0.0.1:45358/PubSubHub',
      { message: 'Hello' },
      'json'
    );
  }
}
