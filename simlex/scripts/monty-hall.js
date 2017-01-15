/// <reference path="../typings/jquery.d.ts" />
window.onload = function (ev) {
    var mh = new MontyHall();
};
var MontyHall = (function () {
    function MontyHall() {
        var _this = this;
        this.createBlock = function () {
            _this._mhBlock.html("");
            $("<h4>Парадокс Манти Холла</h4>").addClass("monty-hall__header").appendTo(_this._mhBlock);
            _this._table = $("<table></table>").addClass("table table-condensed table-bordered monty-hall__table").appendTo(_this._mhBlock);
            var tr1 = $("<tr><td>Попыток</td><td id=\"monty-hall-count\"></td></tr>").appendTo(_this._table);
            var tr1 = $("<tr><td>Неправильных ответов</td><td id=\"monty-hall-false-count\"></td></tr>").appendTo(_this._table);
            var tr1 = $("<tr><td>Правильных ответов</td><td id=\"monty-hall-true-count\"></td></tr>").appendTo(_this._table);
            var tr1 = $("<tr><td>Процент</td><td id=\"monty-hall-percent\"></td></tr>").appendTo(_this._table);
            _this._result = new MontyHallResult();
            _this.fillResult();
            _this.createStep();
        };
        this.createStep = function () {
            if (_this._stepRow) {
                _this._stepRow.remove();
            }
            _this._stepRow = $("<div></div>").addClass("row").appendTo(_this._mhBlock);
            var cloneItem = $("<div><a href=\"#\"><img alt=\"Монти Холл. Закрытая дверь\" src=\"/content/dist/i/static/monty-hall/door.jpg\"/></a></div>").addClass("monty-hall__door");
            var door1 = cloneItem.clone().attr("data-door", "1").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(_this._stepRow);
            var door2 = cloneItem.clone().attr("data-door", "2").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(_this._stepRow);
            var door3 = cloneItem.clone().attr("data-door", "3").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(_this._stepRow);
            var prizeDoorIndex = _this.getRandomArbitrary(1, 3);
            $("[data-door=\"" + prizeDoorIndex + "\"]").attr("data-prize", "true");
        };
        this.getRandomArbitrary = function (min, max) {
            return Math.floor(Math.random() * (max + 1 - min) + min);
        };
        this.openFalseDoor = function () {
            var hasOpened = false;
            $.each(_this._mhBlock.find(".monty-hall__door"), function (i, e) {
                var div = $(e);
                var isOpenedDoor = div.attr("data-opened") === "true";
                var isSelectedDoor = div.attr("data-selected") === "true";
                var isPrizeDoor = div.attr("data-prize") === "true";
                if (hasOpened) {
                    return;
                }
                if (!isSelectedDoor && !isPrizeDoor) {
                    div.attr("data-opened", "true");
                    div.find("img").attr("src", "/content/dist/i/static/monty-hall/door-empty.jpg");
                    hasOpened = true;
                }
            });
        };
        this._mhBlock = $("#monty-hall");
        this.createBlock();
        this._mhBlock.on("click", "a", function (e) {
            var a = $(e.currentTarget);
            var item = a.parent(".monty-hall__door");
            e.preventDefault();
            var isOpenedDoor = item.attr("data-opened") === "true";
            var isSelectedDoor = item.attr("data-selected") === "true";
            var isPrizeDoor = item.attr("data-prize") === "true";
            if (isOpenedDoor) {
                return;
            }
            var isNextStep = _this._mhBlock.find("[data-selected=\"true\"]").length === 1;
            if (isNextStep) {
                _this._result.Count++;
                if (isPrizeDoor) {
                    _this._result.TrueCount++;
                }
                else {
                    _this._result.FalseCount++;
                }
                _this.fillResult();
                _this.createStep();
            }
            else {
                item.attr("data-selected", "true");
                _this.openFalseDoor();
            }
        });
    }
    MontyHall.prototype.fillResult = function () {
        this._table.find("td#monty-hall-count").html(this._result.Count.toString());
        this._table.find("td#monty-hall-true-count").html(this._result.TrueCount.toString());
        this._table.find("td#monty-hall-false-count").html(this._result.FalseCount.toString());
        this._table.find("td#monty-hall-percent").html(this._result.Percent().toString());
    };
    return MontyHall;
}());
var MontyHallResult = (function () {
    function MontyHallResult() {
        var _this = this;
        this.Count = 0;
        this.TrueCount = 0;
        this.FalseCount = 0;
        this.Percent = function () {
            return (_this.Count === 0 || _this.TrueCount === 0) ? 0 : Math.round(_this.TrueCount * 100 / _this.Count);
        };
    }
    return MontyHallResult;
}());
