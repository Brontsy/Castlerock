using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Web.Models
{
    public class ImageUploadViewModel
    {
        private int? _numberOfImagesToUpload = null;

        /// <summary>
        /// Gets and sets the path the image should be saved into
        /// on the web server.
        /// Eg. /Properties/Boronia/
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets the maximum number of images to upload
        /// Null means as many as the user wants
        /// </summary>
        public int? NumberOfImagesToUpload
        {
            get { return this._numberOfImagesToUpload; }
            set { this._numberOfImagesToUpload = value; }
        }

        /// <summary>
        /// Gets the number of squares we should draw on the page
        /// </summary>
        public int ImageSquaresToDraw
        {
            get
            {
                if (this.NumberOfImagesToUpload.HasValue)
                {
                    return this.NumberOfImagesToUpload.Value;
                }

                return 5;
            }
        }
    }
}