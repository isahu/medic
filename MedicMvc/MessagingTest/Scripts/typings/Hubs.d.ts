



















// Get signalr.d.ts.ts from https://github.com/borisyankov/DefinitelyTyped (or delete the reference)
/// <reference path="signalr/signalr.d.ts" />
/// <reference path="jquery/jquery.d.ts" />

////////////////////
// available hubs //
////////////////////
//#region available hubs

interface SignalR {


    /**
      * The hub implemented by MessagingTest.Hubs.MessageHub
      */
    messageHub : MessageHub;

}
//#endregion available hubs

///////////////////////
// Service Contracts //
///////////////////////
//#region service contracts


//#region MessageHub hub

interface MessageHub {
    
    /**
      * This property lets you send messages to the MessageHub hub.
      */
    server : MessageHubServer;

    /**
      * The functions on this property should be replaced if you want to receive messages from the MessageHub hub.
      */
    client : MessageHubClient;
}


interface MessageHubServer {


    /** 
      * Sends a "requestMessages" message to the MessageHub hub.
      * Contract Documentation: ---

      * @param request {MessageRequest} 

      * @return {JQueryPromise of void}
      */
    requestMessages(request : MessageRequest) : JQueryPromise<void>;


    /** 
      * Sends a "requestUnreadCount" message to the MessageHub hub.
      * Contract Documentation: ---

      * @return {JQueryPromise of void}
      */
    requestUnreadCount() : JQueryPromise<void>;


    /** 
      * Sends a "requestUnread" message to the MessageHub hub.
      * Contract Documentation: ---

      * @return {JQueryPromise of void}
      */
    requestUnread() : JQueryPromise<void>;


    /** 
      * Sends a "sendMessage" message to the MessageHub hub.
      * Contract Documentation: ---

      * @param message {string} 

      * @param convId {number} 

      * @return {JQueryPromise of void}
      */
    sendMessage(message : string, convId : number) : JQueryPromise<void>;


    /** 
      * Sends a "messageRecieved" message to the MessageHub hub.
      * Contract Documentation: ---

      * @param messageId {number} 

      * @return {JQueryPromise of void}
      */
    messageRecieved(messageId : number) : JQueryPromise<void>;


    /** 
      * Sends a "messageRead" message to the MessageHub hub.
      * Contract Documentation: ---

      * @param messageId {number} 

      * @return {JQueryPromise of void}
      */
    messageRead(messageId : number) : JQueryPromise<void>;


    /** 
      * Sends a "fetchContactRequests" message to the MessageHub hub.
      * Contract Documentation: ---

      * @return {JQueryPromise of void}
      */
    fetchContactRequests() : JQueryPromise<void>;


    /** 
      * Sends a "approveContacts" message to the MessageHub hub.
      * Contract Documentation: ---

      * @return {JQueryPromise of void}
      */
    approveContacts() : JQueryPromise<void>;


    /** 
      * Sends a "fetchContacts" message to the MessageHub hub.
      * Contract Documentation: ---

      * @return {JQueryPromise of void}
      */
    fetchContacts() : JQueryPromise<void>;

}



interface MessageHubClient
{


    /**
      * Set this function with a "function(count : number){}" to receive the "sendUnreadCount" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param count {number} 

      * @return {void}
      */
    sendUnreadCount : (count : number) => void;


    /**
      * Set this function with a "function(response : MessageRequestResponse){}" to receive the "sendRequestResponse" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param response {MessageRequestResponse} 

      * @return {void}
      */
    sendRequestResponse : (response : MessageRequestResponse) => void;


    /**
      * Set this function with a "function(msgArray : MessageBodyStruct[]){}" to receive the "sendMessages" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param msgArray {MessageBodyStruct[]} 

      * @return {void}
      */
    sendMessages : (msgArray : MessageBodyStruct[]) => void;


    /**
      * Set this function with a "function(contactNames : string[]){}" to receive the "contactsAll" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param contactNames {string[]} 

      * @return {void}
      */
    contactsAll : (contactNames : string[]) => void;


    /**
      * Set this function with a "function(contactName : string){}" to receive the "contactAdded" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param contactName {string} 

      * @return {void}
      */
    contactAdded : (contactName : string) => void;


    /**
      * Set this function with a "function(contactName : string){}" to receive the "contactRemoved" message from the MessageHub hub.
      * Contract Documentation: ---

      * @param contactName {string} 

      * @return {void}
      */
    contactRemoved : (contactName : string) => void;

}


//#endregion MessageHub hub


//#endregion service contracts



////////////////////
// Data Contracts //
////////////////////
//#region data contracts



/**
  * Data contract for MessageBodyStruct
  */
interface MessageBodyStruct {

    Sender : string;

    Timestamp : string;

    Conversation : number;

    Text : string;

}



/**
  * Data contract for MessageRequestResponse
  */
interface MessageRequestResponse {

    IsValid : boolean;

    StatusMsg : string;

    Messages : MessageBodyStruct[];

}



/**
  * Data contract for MessageRequest
  */
interface MessageRequest {

    StartTime : string;

    EndTime : string;

    MessageIds : number[];

    All : boolean;

    UnreadOnly : boolean;

}


//#endregion data contracts

