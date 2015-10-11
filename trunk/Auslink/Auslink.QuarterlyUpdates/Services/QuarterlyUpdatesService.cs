using Auslink.QuarterlyUpdates.Models;
using Auslink.QuarterlyUpdates.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auslink.QuarterlyUpdates.Services
{
    public interface IQuarterlyUpdatesService
    {
        IList<QuarterlyUpdate> GetQuarterlyUpdates();

        QuarterlyUpdate GetQuarterlyUpdateById(int quarterlyUpdateId);
        
        void Save(QuarterlyUpdate quarterlyUpdate);

        void Delete(int quarterlyUpdateId);
    }

    internal class QuarterlyUpdatesService : IQuarterlyUpdatesService
    {
        private IQuarterlyUpdatesRepository _repository;

        public QuarterlyUpdatesService(IQuarterlyUpdatesRepository repository)
        {
            this._repository = repository;
        }

        public IList<QuarterlyUpdate> GetQuarterlyUpdates()
        {
            return this._repository.GetQuarterlyUpdates();
        }

        public QuarterlyUpdate GetQuarterlyUpdateById(int quarterlyUpdateId)
        {
            return this._repository.GetQuarterlyUpdateById(quarterlyUpdateId);
        }
    

        public void Save(QuarterlyUpdate quarterlyUpdate)
        {
            this._repository.Save(quarterlyUpdate);
        }


        public void Delete(int quarterlyUpdateId)
        {
            this._repository.Delete(quarterlyUpdateId);
        }
    }
}
