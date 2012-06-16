using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Images.Models
{
    public class ImageUploadResult
    {
        private int _imageId;
        private string _storageId;
        private string _source;
        private int _width = 0;
        private int _height = 0;

        /// <summary>
        /// Gets and sets the id of the image saved in the repository
        /// </summary>
        public int ImageId
        {
            get { return this._imageId; }
            internal set { this._imageId = value; }
        }
        
        /// <summary>
        /// Gets and sets the id of this image on the storage server
        /// </summary>
        public string StorageId
        {
            get { return this._storageId; }
            internal set { this._storageId = value; }
        }

        /// <summary>
        /// Gets and sets the source of this image, ie where its located
        /// </summary>
        public string Source
        {
            get { return this._source; }
            internal set { this._source = value; }
        }

        /// <summary>
        /// Gets and sets the width of the image
        /// </summary>
        public int Width
        {
            get { return this._width; }
            internal set { this._width = value; }
        }

        /// <summary>
        /// Gets and sets the height of the image
        /// </summary>
        public int Height
        {
            get { return this._height; }
            internal set { this._height = value; }
        }
    }
}
