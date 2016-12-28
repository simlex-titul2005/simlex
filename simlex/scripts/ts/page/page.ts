/// <reference path="../typings/jquery.d.ts" />

class Page {
    private _scrollTop: number = 0;
    private _window: JQuery;
    private _top: number = 600;
    private _upButton: JQuery;
    private _isMobileDevice: boolean = false;
    private _page: JQuery;
    private _page_col1: JQuery;
    private _page_col2: JQuery;
    private _page_col3: JQuery;

    constructor() {
        this._window = $(window);
        this._upButton = $(".nav-bar .nav-bar--up-btn");
        this._page = $(".page");
        this._page_col1 = this._page.find(".page-col-2");
        this._page_col2 = this._page.find(".page-col-7");
        this._page_col3 = this._page.find(".page-col-3");

        var userAgent: string = navigator.userAgent.toLowerCase();
        this._isMobileDevice = (/android|webos|iris|bolt|mobile|iphone|ipad|ipod|iemobile|blackberry|windows phone|opera mobi|opera mini/i.test(userAgent)) ? true : false;
    }

    public initialize(): void {
        if (!this._isMobileDevice) {
            this._window.scroll((e: JQueryKeyEventObject): void => {
                this._scrollTop = this._window.scrollTop();
                if (this._top < this._scrollTop) {
                    this._upButton.addClass("visible");
                    this._page.addClass("fixed");
                }
                else {
                    this._upButton.removeClass("visible");
                    this._page.removeClass("fixed");
                }
            });
        }
    };
}