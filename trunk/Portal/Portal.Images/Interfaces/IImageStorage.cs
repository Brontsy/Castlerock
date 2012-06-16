using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Portal.Images.Models;

namespace Portal.Images.Interfaces
{
    /// <summary>
    /// Interface to save and load images to.
    /// Eg. Local c:, azure blob storage etc
    /// </summary>
    public interface IImageStorage
    {
        /// <summary>
        /// Uploads a colletion of files to the image server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        IList<ImageUploadResult> UploadImages(HttpFileCollectionBase files, string domain, string imagePath);

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="files">the file to upload</param>
        /// <param name="domain">the domain this website lives in. eg castlerockproperty, auslinkproperty etc</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        ImageUploadResult UploadImage(HttpPostedFileBase file, string domain, string imagePath);
    }
}
