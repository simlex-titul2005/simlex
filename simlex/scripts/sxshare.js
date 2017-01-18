/// <reference path="../typings/jquery.d.ts" />
window.onload = function (ev) {
    var share = new SxShare(".sxshare", true);
};
var SxShare = (function () {
    function SxShare(elements, showCounters) {
        var _this = this;
        if (showCounters === void 0) { showCounters = false; }
        this._counters = new Array();
        this._array = $(elements);
        this._showCounters = showCounters;
        if (this._array.length === 0)
            return;
        $.each(this._array, function (index, element) {
            var a = $(element);
            var netCode = a.attr("data-net-code");
            var showCounter = a.attr("data-show-counter") === "true";
            var url = a.attr("data-url");
            var img = a.attr("data-image");
            var title = a.attr("data-title");
            var desc = a.attr("data-desc");
            var item = new SxShareItem(netCode, url, img, title, desc);
            a.on("click", function (e) {
                e.preventDefault();
                _this.openWondow(item);
            });
            var existItem = $.grep(_this._counters, function (e) { return e.Url === url && e.NetCode === netCode; }).length > 0;
            if (existItem) {
                return;
            }
            if (!showCounter) {
                return;
            }
            _this._counters.push(new SxShareCounter(netCode, url));
        });
        if (!this._showCounters) {
            return;
        }
        this.showCounters();
    }
    SxShare.prototype.openWondow = function (item) {
        item.popup();
    };
    SxShare.prototype.showCounters = function () {
        $.each(this._counters, function (index, counter) {
            counter.getCount();
        });
    };
    return SxShare;
}());
var SxShareItem = (function () {
    function SxShareItem(netCode, url, image, title, desc) {
        var _this = this;
        this.getWindowUrl = function () {
            switch (_this.NetCode) {
                default: return "";
                case "vk":
                    return "http://vk.com/share.php?url=" + encodeURIComponent(_this.Url)
                        + "&title=" + encodeURIComponent(_this.Title)
                        + "&description=" + encodeURIComponent(_this.Description)
                        + "&image=" + encodeURIComponent(_this.Image);
                case "ok":
                    return "http://www.odnoklassniki.ru/dk?st.cmd=addShare&st.s=1"
                        + "&st.comments=" + encodeURIComponent(_this.Title)
                        + "&st._surl=" + encodeURIComponent(_this.Url);
            }
        };
        this.popup = function () {
            window.open(_this.getWindowUrl(), '', 'left=' + (screen.width - 630) / 2 + ',top=' + (screen.height - 440) / 2 + ',toolbar=0,status=0,scrollbars=0,menubar=0,location=0,width=630,height=440');
        };
        this.NetCode = netCode;
        this.Url = url;
        this.Image = image;
        this.Title = title;
        this.Description = desc;
    }
    ;
    return SxShareItem;
}());
var SxShareCounter = (function () {
    function SxShareCounter(netCode, url) {
        var _this = this;
        this.getCount = function () {
            var self = _this;
            var w = window;
            switch (_this.NetCode) {
                case "vk":
                    $.getJSON("https://vk.com/share.php?act=count&index=1&url=" + encodeURIComponent(_this.Url) + '&callback=?', function (response) { });
                    if (!w.VK) {
                        w.VK = {};
                    }
                    w.VK.Share = {
                        count: function (index, count) {
                            self.setCount(count);
                        }
                    };
                    break;
                case "ok":
                    $.getJSON("https://connect.ok.ru/dk?st.cmd=extLike&uid=1&ref=" + encodeURIComponent(_this.Url) + '&callback=?', function (response) { });
                    if (!w.ODKL)
                        w.ODKL = {};
                    w.ODKL.updateCount = function (index, count) {
                        self.setCount(count);
                    };
                    break;
            }
        };
        this.setCount = function (count) {
            $(".share-buttons [data-url=\"" + _this.Url + "\"] .sxshare__counter").html(count.toString());
        };
        this.NetCode = netCode;
        this.Url = url;
    }
    return SxShareCounter;
}());
