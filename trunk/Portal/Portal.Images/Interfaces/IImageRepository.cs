using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using Portal.Images.Models;

namespace Portal.Images.Interfaces
{
    /// <summary>
    /// Interface to save and retrieve the location of images
    /// </summary>
    public interface IImageRepository : IBaseDao<Image, int>
    {
        
    }
}
