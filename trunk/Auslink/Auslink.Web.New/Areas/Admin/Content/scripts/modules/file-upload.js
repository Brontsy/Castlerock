


(function ($) {

    function FileUpload(dropZone, textbox, path) {
        this.initialise(dropZone, textbox, path);
    }

    $.fn.fileUpload = function (textbox, path) {

        return new FileUpload($(this), textbox, path);
    };


    FileUpload.prototype =
    {
        _dropZone: null,
        _path: null,
        _textbox: null,

        initialise: function (dropZone, textbox, path) {

            this._dropZone = $(dropZone);
            this._path = path;
            this._textbox = $(textbox);

            this.addEvents();

            this.addRemoveEvents();
        },

        addEvents: function () {
            var me = this;

            $(document).bind('dragenter', function (event) { me.dragEnter(event); });
            $(this._dropZone).bind('dragleave', function (event) { me.dragLeave(event); });
            $(document).bind('dragover', function (event) { me.dragOver(event); });
            $(document).bind('drop', function (event) { me.drop(event); });

        },

        addRemoveEvents: function () {
            $('.file, .folder').on('mouseover', function (event) {
                $(this).find('a.remove').removeClass('hidden');
            });

            $('.file, .folder').on('mouseleave', function (event) {
                $(this).find('a.remove').addClass('hidden');
            });
        },

        dragEnter: function (event) {
            event.preventDefault();
        },

        dragLeave: function (event) {
            event.preventDefault();

            this._dropZone.removeClass('file-dragged');
        },

        dragOver: function (event) {
            event.preventDefault();

            // if we dragged it over the dropzone
            if (this._dropZone.find($(event.target)).length > 0) {
                this._dropZone.addClass('file-dragged');
            }
        },

        drop: function (event) {
            event.preventDefault();

            this._dropZone.removeClass('file-dragged');
            this._dropZone.parents('form').addClass('file-uploading')


            // if we dragged it over the dropzone
            if (this._dropZone.find($(event.target)).length > 0) {

                var files = event.originalEvent.dataTransfer.files;

                var formData = new FormData();

                $.each(files, function (index, file) {
                    formData.append('file-' + index, file);
                });

                this.upload(formData);

            }
        },

        upload: function (formData) {
            var me = this;

            var xhr = new XMLHttpRequest();
            xhr.upload.addEventListener("progress", this.progress, false);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        me.uploadComplete(xhr.responseText);
                    }
                    else {
                        alert('fail');
                    }
                }
            }.bind(this);

            xhr.open("POST", '/admin/file-uploader/upload?path=' + this._path);
            xhr.send(formData);
            return;
        },

        uploadComplete: function (response) {

            var json = JSON.parse(response);
            var fileName = json.fileName;

            this._textbox.val(fileName);

            this._dropZone.parents('form').removeClass('file-uploading');

            $(window).trigger('file-upload-complete', { fileName: fileName, path: json.path, uri: json.uri });
        }
    };



})(jQuery);
