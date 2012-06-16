using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Nhibernate;
using Portal.Images.Models;
using Portal.Images.Interfaces;
using NHibernate;

namespace Portal.Images.Daos
{
    public class ImageNhibernateRepository : AbstractNHibernateDao<Image, int>, IImageRepository
    {
        public ImageNhibernateRepository(ISession session)
            :base(session)
        {

        }
    }
}
