/// <reference path="../typings/knockout/knockout.d.ts"/>
/// <reference path="../typings/signalr/signalr.d.ts"/>
/// <reference path="../typings/jquery/jquery.d.ts"/>
/// <reference path="MsgVMClasses.ts"/>

class LayoutViewModel {
    hub: MessageHub;
    unreadCount: KnockoutObservable<number>;
    statusText: KnockoutComputed<string>;

    constructor(hub: MessageHub) {
        this.hub = hub;
        this.unreadCount = ko.observable(0);
        this.statusText = ko.computed({
            owner: this,
            read: () => {
                if (this.unreadCount() == 0)
                    return "No unread messages";
                else
                    return "You have " + this.unreadCount + " unread messages.";
            }
        });

        // hub binding
        hub.client.sendUnreadCount = (count: number) => {
            this.unreadCount(count);
        }
    }
}

var layoutVM: LayoutViewModel;

$(() => {
    var msgHub: MessageHub = $.connection.messageHub;

    layoutVM = new LayoutViewModel(msgHub);

    ko.applyBindings(layoutVM);
});