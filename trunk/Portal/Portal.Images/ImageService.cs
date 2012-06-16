using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Portal.Images.Models;
using System.Web;
using Portal.Images.Interfaces;
using Common.Nhibernate;
using Portal.Websites.Interfaces;

namespace Portal.Images
{
    public class ImageService : IImageService
    {
        private IImageStorage _imageStorage = null;
        private IImageRepository _imageRepository = null;
        private ITransactionManager _transactionManager = null;
        private IWebsite _website = null;

        public ImageService(IWebsite website, IImageStorage imageStorage, IImageRepository imageRepository, ITransactionManager transactionManager)
        {
            this._website = website;
            this._imageStorage = imageStorage;
            this._imageRepository = imageRepository;
            this._transactionManager = transactionManager;
        }

        /// <summary>
        /// Uploads a colletion of files to the image server
        /// </summary>
        /// <param name="files">the files to upload</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>list of result objects with filename and success / fail messages</returns>
        public IList<ImageUploadResult> UploadImages(HttpFileCollectionBase files, string imagePath)
        {
            // Upload hte image to the storage
            IList<ImageUploadResult> results = this._imageStorage.UploadImages(files, this._website.Domain, imagePath);

            foreach (ImageUploadResult result in results)
            {
                Image image = this.SaveImage(new Image(result, this._website.Id));
                result.ImageId = image.Id;
            }
            
            return results;
        }

        /// <summary>
        /// Uploads a file to the image server
        /// </summary>
        /// <param name="files">the file to upload</param>
        /// <param name="imagePath">The path to save the image to</param>
        /// <returns>result object with filename and success / fail messages</returns>
        public ImageUploadResult UploadImage(HttpPostedFileBase file, string imagePath)
        {
            // Upload hte image to the storage
            ImageUploadResult result = this._imageStorage.UploadImage(file, this._website.Domain, imagePath);

            // Save the result to our repository
            Image savedImage = this.SaveImage(new Image(result, this._website.Id));
            result.ImageId = savedImage.Id;

            return result;
        }

        /// <summary>
        /// Gets a specific image
        /// </summary>
        /// <param name="id">the id of the image to load</param>
        public Image GetImage(int id)
        {
            return this._imageRepository.GetById(id);
        }

        /// <summary>
        /// Saves a specific image to the repository
        /// </summary>
        /// <param name="image">the image to save</param>
        private Image SaveImage(Image image)
        {
            try
            {
                this._transactionManager.BeginTransaction();

                this._imageRepository.SaveOrUpdate(image);

                this._transactionManager.CommitTransaction();
            }
            catch (Exception e)
            {
                if (this._transactionManager.IsInTransaction())
                {
                    this._transactionManager.RollbackTransaction();
                }

                // Add additional data about the member to a new exception
                ApplicationException exception = new ApplicationException("Probelm saving image", e);
                exception.Data.Add("Image Id", image.Id);

                throw exception;
            }

            return image;
        }
    }
}
