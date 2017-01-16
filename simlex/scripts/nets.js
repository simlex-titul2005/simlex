/// <reference path="../typings/jquery.d.ts" />
var Nets = (function () {
    function Nets(settings) {
        var _this = this;
        this.getData = function (a, set) {
            var body = a.closest(".panel").find(".panel-body");
            $.ajax({
                method: "get",
                url: set.DataUrl.url,
                data: set.DataUrl.data,
                success: function (data, status, xhr) {
                    body.html(data);
                }
            });
        };
        this._settings = settings;
        this._accordion = $(".accordion");
        var firstItem = this._accordion.find("a[data-net-code]").not(".collapsed");
        var s = $.grep(this._settings, function (e) { return e.Code === firstItem.attr("data-net-code"); })[0];
        this.getData(firstItem, s);
        this._accordion.find("a[data-net-code]").click(function (e) {
            e.preventDefault();
            var a = $(e.currentTarget);
            var code = a.attr("data-net-code");
            var s = $.grep(_this._settings, function (e) { return e.Code === code; })[0];
            if (s) {
                _this.getData(a, s);
            }
        });
    }
    return Nets;
}());
var NetSetting = (function () {
    function NetSetting(code, dataUrl) {
        this.Code = code;
        this.DataUrl = dataUrl;
    }
    return NetSetting;
}());
