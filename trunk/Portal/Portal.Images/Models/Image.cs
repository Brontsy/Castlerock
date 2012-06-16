using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Images.Models
{
    public class Image
    {
        private int _id;
        private string _storageId = string.Empty;
        private int _websiteId;
        private string _source;
        private Dictionary<int, int> _sizes = null;

        /// <summary>
        /// Default constructor for nhibernate
        /// </summary>
        public Image()
        {
        }

        /// <summary>
        /// Creates a new image from the upload result
        /// </summary>
        /// <param name="uploadResult"></param>
        internal Image(ImageUploadResult uploadResult, int websiteId)
        {
            this._storageId = uploadResult.StorageId;
            this._source = uploadResult.Source;
            this._websiteId = websiteId;

            if (this._sizes == null)
            {
                this._sizes = new Dictionary<int, int>();
            }

            // Only add the new size if it is different to any other size in there
            if (!this._sizes.ContainsKey(uploadResult.Width) || !this._sizes.ContainsValue(uploadResult.Height))
            {
                this._sizes.Add(uploadResult.Width, uploadResult.Height);
            }
        }

        /// <summary>
        /// Gets and sets the id of this image
        /// </summary>
        public int Id
        {
            get { return this._id; }
            internal set { this._id = value; }
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
        /// The id of the website this image belongs to
        /// </summary>
        public int WebsiteId
        {
            get { return this._websiteId; }
            internal set { this._websiteId = value; }
        }

        /// <summary>
        /// Gets and sets all the different available sizes this image has
        /// </summary>
        public Dictionary<int, int> Sizes
        {
            get { return this._sizes; }
            internal set { this._sizes = value; }
        }
    }
}
