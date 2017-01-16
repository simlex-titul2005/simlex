/// <reference path="../typings/jquery.d.ts" />

class Nets {
    private _accordion: JQuery;
    private _settings: NetSetting[];

    constructor(settings: NetSetting[]) {
        this._settings = settings;
        this._accordion = $(".accordion");

        var firstItem: JQuery = this._accordion.find("a[data-net-code]").not(".collapsed");
        var s: any = <NetSetting>$.grep(this._settings, function (e) { return e.Code === firstItem.attr("data-net-code") })[0];
        this.getData(firstItem, s);

        this._accordion.find("a[data-net-code]").click((e: JQueryEventObject): void => {
            e.preventDefault();
            var a: JQuery = $(e.currentTarget);
            var code: string = a.attr("data-net-code");
            var s: any = <NetSetting>$.grep(this._settings, function (e) { return e.Code === code; })[0];
            if (s) {
                this.getData(a, s);
            }
        });
    }

    private getData = (a: JQuery, set: NetSetting): void => {
        var body: JQuery = a.closest(".panel").find(".panel-body");
        $.ajax({
            method: "get",
            url: set.DataUrl.url,
            data: set.DataUrl.data,
            success: (data: any, status: string, xhr: JQueryXHR): void => {
                body.html(data);
            }
        });
    };
}

class NetSetting {
    Code: string;
    DataUrl: any;

    constructor(code: string, dataUrl: any) {
        this.Code = code;
        this.DataUrl = dataUrl;
    }
}