

Element.NativeEvents = Object.append(Element.NativeEvents, {
    dragenter: 2, dragover: 2, drop: 2, dragleave: 2
});


FileUpload = new Class({

    _dropZoneCssClass: null,
    _path: null,
    _images: new Array(),
    _imageIds: new Array(),
    
    initialize: function (dropZoneCssClass, path)
    {
        this._dropZoneCssClass = dropZoneCssClass;
        this._path = path;

        this.createDropEvents();
    },

    dropZone: function()
    {
        return $$('.'+this._dropZoneCssClass);
    },

    createDropEvents: function ()
    {
        var body = $$('.content');

        body.addEvent('dragEnter', this.dragEnter.bind(this));

        $$('body').addEvents({

            dragenter: this.dragEnter.bind(this),
            dragleave: this.dragLeave.bind(this),
            dragover: this.dragOver.bind(this),
            drop: this.drop.bind(this),
        });
    },

    dragEnter: function (e)
    {
        e.stop();
    },

    dragLeave: function (e)
    {
        e.stop();
        //this.dropZone()[0].removeClass('active');
    },

    dragOver: function (e)
    {
        e.stop();
        //this.dropZone()[0].addClass('active');
    },

    drop: function (e)
    {
        e.stop();



        var parent = this.dropZone()[0].removeClass('active').getParent();

        var paddingTop = (parent.getStyle('height').toInt() / 2) - 19;

        if($$('.loading-large').length == 0)
        {
            var loading = new Element('div', {

                'html': 'Uploading',
                'class': 'loading-large',
                styles: {
                    width: parent.getStyle('width'),
                    height: parent.getStyle('height').toInt() - paddingTop,
                    'padding-top': paddingTop,
                    'background-position': '150px ' + (paddingTop - 40) + 'px'
                }
            });

            loading.inject(this.dropZone()[0], 'before');
        }
        else
        {
            $$('.loading-large').removeClass('hidden');
        }


        var files = e.event.dataTransfer.files;

        var formData = new FormData();
        Array.each(files, function (file, index)
        {
            formData.append('File-' + index, file);
        });

        this.upload(formData);
    },

    upload: function (formData)
    {
        var xhr = new XMLHttpRequest();

        xhr.upload.addEventListener("progress", this.progress, false);
        xhr.onreadystatechange = function ()
        {
            if (xhr.readyState == 4)
            {
                if (xhr.status == 200)
                {
                    this.uploadComplete(xhr.responseText);
                }
                else
                {
                    alert('fail');
                }
            }
        } .bind(this);

        xhr.open("POST", '/File-Manager/Upload?path='+this._path);
        xhr.send(formData);
        return;
    },

    progress: function (e)
    {

    },


    uploadComplete: function (response)
    {
        var json = JSON.decode(response);
        
            $$('.loading-large').addClass('hidden');
        json.each(function(item, index) {

//            var image = new Element('img', 
//            {
//                src: item.Source,
//                width: this.dropZone()[0].getStyle('width'),
//                styles: 
//                {
//                    'display': 'block'
//                }
//            });
//            
//            image.onload = function() { this.imageLoaded(image); }.bind(this);

//            //this.imageIds.set('value', this.imageIds.get('value') + '|' + item.ImageId);
//            this._imageIds.push(item.ImageId);

        }.bind(this));

        //$('imageIds').set('value', JSON.encode(this._imageIds));
    },

    imageLoaded: function(image, event, b)
    {
//        this.dropZone()[0].setStyle('height', image.getStyle('height'));
//        image.inject(this.dropZone()[0]);
//        this.dropZone()[0].addClass('hasImage');

    }
});

