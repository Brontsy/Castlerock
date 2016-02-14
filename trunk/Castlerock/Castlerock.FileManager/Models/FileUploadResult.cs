using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Castlerock.FileManager.Models
{
    public class FileUploadResult
    {
        private string _storageId;
        private string _source;
        
        /// <summary>
        /// Gets and sets the id of this file on the storage server
        /// </summary>
        public string StorageId
        {
            get { return this._storageId; }
            internal set { this._storageId = value; }
        }

        /// <summary>
        /// Gets and sets the source of this file, ie where its located
        /// </summary>
        public string Source
        {
            get { return this._source; }
            internal set { this._source = value; }
        }
    }
}
