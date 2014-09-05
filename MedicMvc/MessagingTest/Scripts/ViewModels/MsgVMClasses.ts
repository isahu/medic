/// <reference path="../typings/knockout/knockout.d.ts"/>
/// <reference path="../typings/signalr/signalr.d.ts"/>

interface IMessage {
    sender: string;
    conversationId: number;
    timestamp?: Date;
    text: string;

}

class ConversationVM {
    id: number;
    owner: MessagingVM;

    //sendMessageToServer(msg: IMessage): void;

    //sendMessage = (): void => {
    //
    //}
}

class MessagingVM {
    hub: MessageHub;
    conversations: KnockoutObservableArray<ConversationVM>;

    contacts: KnockoutObservableArray<string>;

    requestContacts = (): void => {
        this.hub.server.fetchContacts();
    }

    loadContacts = (list: Array<string>): void => {
        this.contacts(list);
    }

    contactAdded = (name: string): void => {
        this.contacts.push(name);
    }

    contactRemoved = (name: string): void => {
        this.contacts.remove(name);
    }

    constructor(hub: MessageHub) {
        this.hub = hub;
        this.conversations = ko.observableArray([]);
        this.contacts = ko.observableArray([]);

        hub.client.contactsAll = this.loadContacts;
        hub.client.contactAdded = this.contactAdded;
    }
}