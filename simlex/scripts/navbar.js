/// <reference path="../typings/jquery.d.ts" />
/*Navbar module */
var Navbar = (function () {
    function Navbar() {
    }
    Navbar.prototype.initialize = function (navbar) {
        var _this = this;
        this._navbar = $(navbar);
        this._page = $(".page");
        this._about = $(".page-col-2");
        this._navbarTemp = $("<ul></ul>").addClass("nav-bar-temp");
        $(".nav-bar-item").clone().removeAttr("class").appendTo(this._navbarTemp);
        this._navbarTemp.appendTo(this._navbar);
        this._navbar.find(".nav-bar--menu-btn a").on("click", function (e) {
            var w = 250;
            var visible = _this._about.hasClass("visible");
            if (!visible) {
                _this._about.fadeToggle("fast");
                _this._page.animate({
                    "padding-left": w + "px"
                }, "fast", function () {
                    _this._about.toggleClass("visible");
                });
                return;
            }
            _this._about.fadeToggle();
            _this._page.animate({
                "padding-left": 0
            }, "fast", function () {
                _this._about.toggleClass("visible");
            });
        });
        this._navbar.find(".nav-bar--toggle-btn a").on("click", function (e) {
            e.preventDefault();
            var a = $(e.currentTarget);
            var li = a.parent("li");
            var i = a.find("i");
            var isShow = i.hasClass("fa-plus");
            i.toggleClass("fa-link");
            i.toggleClass("fa-plus");
            if (!isShow) {
                _this._navbarTemp.animate({
                    "top": 0
                }, "fast");
                return;
            }
            _this._navbarTemp.animate({
                "top": "-40px"
            }, "fast");
        });
    };
    return Navbar;
}());
