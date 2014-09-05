/// <reference path="../typings/knockout/knockout.d.ts"/>
/// <reference path="../typings/signalr/signalr.d.ts"/>

var ConversationVM = (function () {
    function ConversationVM() {
    }
    return ConversationVM;
})();

var MessagingVM = (function () {
    function MessagingVM(hub) {
        var _this = this;
        this.requestContacts = function () {
            _this.hub.server.fetchContacts();
        };
        this.loadContacts = function (list) {
            _this.contacts(list);
        };
        this.contactAdded = function (name) {
            _this.contacts.push(name);
        };
        this.contactRemoved = function (name) {
            _this.contacts.remove(name);
        };
        this.hub = hub;
        this.conversations = ko.observableArray([]);
        this.contacts = ko.observableArray([]);

        hub.client.contactsAll = this.loadContacts;
        hub.client.contactAdded = this.contactAdded;
    }
    return MessagingVM;
})();
//# sourceMappingURL=MsgVMClasses.js.map
