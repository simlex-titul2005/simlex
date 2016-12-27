/// <reference path="../typings/jquery.d.ts" />

class SxComments {
    private _comments: JQuery;
    private _form: JQuery;
    private _postUrl: string;
    private _target: JQuery;

    constructor(comments: any, postUrl: string, target: any) {
        this._comments = $(comments);
        this._form = this._comments.find(".sx-new-comment");
        this._postUrl = postUrl;
        this._target = $(target);
    }

    public initialize(): void {
        this._comments.on("click", ".comment__reply > a", (e: JQueryEventObject): void => {
            e.preventDefault();
            var a: JQuery = $(e.currentTarget);
            var comment: JQuery = a.closest(".sx-comment");
            var existForm: boolean = comment.find(".sx-new-comment").length > 0;
            if (existForm) return;

            var form: JQuery = this._form.clone();
            form.hide().appendTo(comment).fadeIn(.1, () => {
                var id: string = comment.attr("id").replace("sx-comment-", "");
                $("<input type=\"hidden\" name=\"CommentId\" value=\"" + id + "\" />").appendTo(form.find("form"));
                this._comments.find(".sx-comment").not("[id=\"sx-comment-" + id + "\"]").find(".sx-new-comment").remove();
                comment.find(".sx-comments__cancel-reply").show();
                this._form.hide();
            });
        });

        this._comments.on("click", ".sx-comments__cancel-reply", (e: JQueryEventObject): void => {
            e.preventDefault();
            this._comments.find(".sx-comment .sx-new-comment").remove();
            this._form.show();
        });

        this._comments.on("submit", ".sx-new-comment form", (e: JQueryEventObject): void => {
            e.preventDefault();
            var form: JQuery = $(e.currentTarget);
            $.ajax({
                method: "post",
                url: this._postUrl,
                data: form.serialize(),
                success: (data: any, status: string, xhr: JQueryXHR): void => {
                    this._target.html(data);
                }
            });
        });
    }
}