/// <reference path="../typings/knockout/knockout.d.ts"/>
/// <reference path="../typings/signalr/signalr.d.ts"/>
/// <reference path="../typings/jquery/jquery.d.ts"/>
/// <reference path="MsgVMClasses.ts"/>
var LayoutViewModel = (function () {
    function LayoutViewModel(hub) {
        var _this = this;
        this.hub = hub;
        this.unreadCount = ko.observable(0);
        this.statusText = ko.computed({
            owner: this,
            read: function () {
                if (_this.unreadCount() == 0)
                    return "No unread messages";
                else
                    return "You have " + _this.unreadCount + " unread messages.";
            }
        });

        // hub binding
        hub.client.sendUnreadCount = function (count) {
            _this.unreadCount(count);
        };
    }
    return LayoutViewModel;
})();

var layoutVM;

$(function () {
    var msgHub;

    layoutVM = new LayoutViewModel(msgHub);

    ko.applyBindings(layoutVM);
});
//# sourceMappingURL=LayoutViewModel.js.map
