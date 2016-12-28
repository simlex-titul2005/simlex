/// <reference path="../typings/jquery.d.ts" />
var Page = (function () {
    function Page() {
        this._scrollTop = 0;
        this._top = 600;
        this._isMobileDevice = false;
        this._window = $(window);
        this._upButton = $(".nav-bar .nav-bar--up-btn");
        this._page = $(".page");
        this._page_col1 = this._page.find(".page-col-2");
        this._page_col2 = this._page.find(".page-col-7");
        this._page_col3 = this._page.find(".page-col-3");
        var userAgent = navigator.userAgent.toLowerCase();
        this._isMobileDevice = (/android|webos|iris|bolt|mobile|iphone|ipad|ipod|iemobile|blackberry|windows phone|opera mobi|opera mini/i.test(userAgent)) ? true : false;
    }
    Page.prototype.initialize = function () {
        var _this = this;
        if (!this._isMobileDevice) {
            this._window.scroll(function (e) {
                _this._scrollTop = _this._window.scrollTop();
                if (_this._top < _this._scrollTop) {
                    _this._upButton.addClass("visible");
                    _this._page.addClass("fixed");
                }
                else {
                    _this._upButton.removeClass("visible");
                    _this._page.removeClass("fixed");
                }
            });
        }
    };
    ;
    return Page;
}());
