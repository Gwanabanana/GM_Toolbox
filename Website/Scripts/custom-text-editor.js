(function ($) {
    function TextEditor() {
        var $this = this;

        function initialize() {
            $('#Content').summernote({
                focus: true,
                height: 10,
                codemirror: {
                    theme: 'united'
                }
            });
        }

        $this.init = function () {
            initialize();
        }
    }
    $(function () {
        var self = new TextEditor();
        self.init();
    })
}(jQuery))