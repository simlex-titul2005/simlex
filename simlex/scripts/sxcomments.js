/// <reference path="../typings/jquery.d.ts" />
var SxComments = (function () {
    function SxComments(comments, postUrl, target) {
        this._comments = $(comments);
        this._form = this._comments.find(".sx-new-comment");
        this._postUrl = postUrl;
        this._target = $(target);
    }
    SxComments.prototype.initialize = function () {
        var _this = this;
        this._comments.on("click", ".comment__reply > a", function (e) {
            e.preventDefault();
            var a = $(e.currentTarget);
            var comment = a.closest(".sx-comment");
            var existForm = comment.find(".sx-new-comment").length > 0;
            if (existForm)
                return;
            var form = _this._form.clone();
            form.hide().appendTo(comment).fadeIn(.1, function () {
                var id = comment.attr("id").replace("sx-comment-", "");
                $("<input type=\"hidden\" name=\"CommentId\" value=\"" + id + "\" />").appendTo(form.find("form"));
                _this._comments.find(".sx-comment").not("[id=\"sx-comment-" + id + "\"]").find(".sx-new-comment").remove();
                comment.find(".sx-comments__cancel-reply").show();
                _this._form.hide();
            });
        });
        this._comments.on("click", ".sx-comments__cancel-reply", function (e) {
            e.preventDefault();
            _this._comments.find(".sx-comment .sx-new-comment").remove();
            _this._form.show();
        });
        this._comments.on("submit", ".sx-new-comment form", function (e) {
            e.preventDefault();
            var form = $(e.currentTarget);
            $.ajax({
                method: "post",
                url: _this._postUrl,
                data: form.serialize(),
                success: function (data, status, xhr) {
                    _this._target.html(data);
                }
            });
        });
    };
    return SxComments;
}());
