/// <reference path="../typings/jquery.d.ts" />

window.onload = (ev: Event) => {
    var mh = new MontyHall();
};

class MontyHall {
    private _mhBlock: JQuery;
    private _table: JQuery;
    private _stepRow: JQuery;

    private _result: MontyHallResult;

    constructor() {
        this._mhBlock = $("#monty-hall");
        this.createBlock();

        this._mhBlock.on("click", "a", (e: JQueryInputEventObject): void => {
            var a: JQuery = $(e.currentTarget);
            var item: JQuery = a.parent(".monty-hall__door");
            e.preventDefault();

            var isOpenedDoor: boolean = item.attr("data-opened") === "true";
            var isSelectedDoor: boolean = item.attr("data-selected") === "true";
            var isPrizeDoor: boolean = item.attr("data-prize") === "true";

            if (isOpenedDoor) {
                return;
            }

            var isNextStep: boolean = this._mhBlock.find("[data-selected=\"true\"]").length === 1;
            if (isNextStep) {
                this._result.Count++;
                if (isPrizeDoor) { this._result.TrueCount++; }
                else { this._result.FalseCount++; }
                this.fillResult();
                this.createStep();
            }
            else {
                item.attr("data-selected", "true");
                this.openFalseDoor();
            }
        });
    }

    private createBlock = (): void => {
        this._mhBlock.html("");

        $("<h4>Парадокс Манти Холла</h4>").addClass("monty-hall__header").appendTo(this._mhBlock);

        this._table = $("<table></table>").addClass("table table-condensed table-bordered monty-hall__table").appendTo(this._mhBlock);
        var tr1: JQuery = $("<tr><td>Попыток</td><td id=\"monty-hall-count\"></td></tr>").appendTo(this._table);
        var tr1: JQuery = $("<tr><td>Неправильных ответов</td><td id=\"monty-hall-false-count\"></td></tr>").appendTo(this._table);
        var tr1: JQuery = $("<tr><td>Правильных ответов</td><td id=\"monty-hall-true-count\"></td></tr>").appendTo(this._table);
        var tr1: JQuery = $("<tr><td>Процент</td><td id=\"monty-hall-percent\"></td></tr>").appendTo(this._table);
        this._result = new MontyHallResult();
        this.fillResult();

        this.createStep();
    };

    private createStep = () => {
        if (this._stepRow) {
            this._stepRow.remove();
        }

        this._stepRow = $("<div></div>").addClass("row").appendTo(this._mhBlock);
        var cloneItem: JQuery = $("<div><a href=\"#\"><img alt=\"Монти Холл. Закрытая дверь\" src=\"/content/dist/i/static/monty-hall/door.jpg\"/></a></div>").addClass("monty-hall__door");
        var door1 = cloneItem.clone().attr("data-door", "1").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(this._stepRow);
        var door2 = cloneItem.clone().attr("data-door", "2").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(this._stepRow);
        var door3 = cloneItem.clone().attr("data-door", "3").addClass("col-md-4 col-sm-4 col-xs-4").appendTo(this._stepRow);

        var prizeDoorIndex = this.getRandomArbitrary(1, 3);
        $("[data-door=\"" + prizeDoorIndex + "\"]").attr("data-prize", "true");
    };

    private getRandomArbitrary = (min: number, max: number): number => {
        return Math.floor(Math.random() * (max + 1 - min) + min);
    }

    private openFalseDoor = (): void => {
        var hasOpened = false;
        $.each(this._mhBlock.find(".monty-hall__door"), (i: number, e: JQuery): void => {
            var div: JQuery = $(e);
            var isOpenedDoor: boolean = div.attr("data-opened") === "true";
            var isSelectedDoor: boolean = div.attr("data-selected") === "true";
            var isPrizeDoor: boolean = div.attr("data-prize") === "true";

            if (hasOpened) {
                return;
            }

            if (!isSelectedDoor && !isPrizeDoor) {
                div.attr("data-opened", "true");
                div.find("img").attr("src", "/content/dist/i/static/monty-hall/door-empty.jpg");
                hasOpened = true;
            }
        });
    }

    private fillResult() {
        this._table.find("td#monty-hall-count").html(this._result.Count.toString());
        this._table.find("td#monty-hall-true-count").html(this._result.TrueCount.toString());
        this._table.find("td#monty-hall-false-count").html(this._result.FalseCount.toString());
        this._table.find("td#monty-hall-percent").html(this._result.Percent().toString());
    }
}

class MontyHallResult {
    public Count: number = 0;
    public TrueCount: number = 0;
    public FalseCount: number = 0;
    public Percent = (): number => {
        return (this.Count === 0 || this.TrueCount === 0) ? 0 : Math.round(this.TrueCount * 100 / this.Count);
    }
}