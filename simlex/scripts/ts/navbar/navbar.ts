/// <reference path="../typings/jquery.d.ts" />

/*Navbar module */

class Navbar {
    private _navbar: JQuery;
    private _navbarTemp: JQuery;
    private _page: JQuery;
    private _about: JQuery;

    public initialize(navbar: any): void {
        this._navbar = $(navbar);
        this._page = $(".page");
        this._about = $(".page-col-2");

        this._navbarTemp = $("<ul></ul>").addClass("nav-bar-temp");
        $(".nav-bar-item").clone().removeAttr("class").appendTo(this._navbarTemp);
        this._navbarTemp.appendTo(this._navbar);

        this._navbar.find(".nav-bar--menu-btn a").on("click", (e: JQueryEventObject): void => {
            var w: number = 250;
            var visible: boolean = this._about.hasClass("visible");
            if (!visible) {
                this._about.fadeToggle("fast");
                this._page.animate({
                    "padding-left": w + "px"
                }, "fast", (): void => {
                    this._about.toggleClass("visible");
                });

                return;
            }

            this._about.fadeToggle();
            this._page.animate({
                "padding-left": 0
            }, "fast", (): void => {
                this._about.toggleClass("visible");
            });
        });

        this._navbar.find(".nav-bar--toggle-btn a").on("click", (e: JQueryEventObject): void => {
            e.preventDefault();
            var a: JQuery = $(e.currentTarget);
            var li: JQuery = a.parent("li");
            var i: JQuery = a.find("i");
            var isShow = i.hasClass("fa-plus");
            i.toggleClass("fa-link");
            i.toggleClass("fa-plus");
            if (!isShow) {
                this._navbarTemp.animate({
                    "top": 0
                }, "fast");
                return;
            }

            this._navbarTemp.animate({
                "top": "-40px"
            }, "fast");
        });
    }
}