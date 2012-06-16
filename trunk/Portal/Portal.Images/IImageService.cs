using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Images.Models;
using System.Web;

namespace Portal.Images
{
    public interface IImageService
    {
        /// <summary>
        /// Uploads a colletion of files to the image server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        IList<ImageUploadResult> UploadImages(HttpFileCollectionBase files, string imagePath);

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="files">the file to upload</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        ImageUploadResult UploadImage(HttpPostedFileBase file, string imagePath);

        /// <summary>
        /// Gets a specific image
        /// </summary>
        /// <param name="id">the id of the image to load</param>
        Image GetImage(int id);
    }
}
