/// <reference path="../typings/knockout/knockout.d.ts"/>
/// <reference path="../typings/signalr/signalr.d.ts"/>

interface IMessage {
    sender: string;
    timestamp: Date;

}

class ConversationVM {
    owner: MessagingVM;
    
}

class MessagingVM {
    hub: MessageHub;
    conversations: KnockoutObservableArray<ConversationVM>;

    constructor(hub: MessageHub) {

    }
}