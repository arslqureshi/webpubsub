import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { webSocket } from 'rxjs/webSocket';
import { WebPubSubClient } from '@azure/web-pubsub-client';

@Injectable({
  providedIn: 'root',
})
export class WebsocketService {
  private wssLink: string = '';
  private pubSubClient?: WebPubSubClient;

  constructor(private httpClient: HttpClient) {}

  public async connect(): Promise<WebPubSubClient> {
    if (this.wssLink == '') {
      await this.GetWssLink();
    }

    if (this.pubSubClient == null) {
      this.pubSubClient = new WebPubSubClient(this.wssLink);

      this.pubSubClient.on('connected', (resp) => {
        console.log(resp);
      });

      this.pubSubClient.on('server-message', (resp) => {
        console.log(resp, 'server message');
      });

      this.pubSubClient.on('group-message', (resp) => {
        console.log(resp, 'group message');
      });
      this.pubSubClient.start();
      // this.pubSubClient.joinGroup('PubSubHub');
    }

    return this.pubSubClient;
  }

  public async GetWssLink() {
    let id = Math.floor(Math.random() * 11);

    let resp: any = await this.httpClient
      .get(`https://localhost:44358/${id}`)
      .toPromise();
    this.wssLink = resp.url;
  }

  public SendMessage() {
    this.httpClient
      .get('https://localhost:44358/message')
      .subscribe((resp: any) => {});
  }

  ngOnDestroy() {
    this.pubSubClient?.stop();
  }
}
