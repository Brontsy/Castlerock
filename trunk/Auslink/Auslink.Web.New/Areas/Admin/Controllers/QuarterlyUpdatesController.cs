using Auslink.QuarterlyUpdates.Models;
using Auslink.QuarterlyUpdates.Services;
using Auslink.Web.New.Areas.Admin.Models.QuarterlyUpdates;
using Auslink.Web.New.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    [AdminAttribute]
    public class QuarterlyUpdatesController : Controller
    {
        private IQuarterlyUpdatesService _quarterlyUpdatesService;

        public QuarterlyUpdatesController(IQuarterlyUpdatesService quarterlyUpdatesService)
        {
            this._quarterlyUpdatesService = quarterlyUpdatesService;
        }

        public ActionResult Index()
        {
            IList<QuarterlyUpdate> quarterlyUpdates = this._quarterlyUpdatesService.GetQuarterlyUpdates();

            IList<QuarterlyUpdateViewModel> viewModel = quarterlyUpdates.Select(o => new QuarterlyUpdateViewModel(o)).ToList();

            return View("Index", viewModel);
        }

        public ActionResult Add()
        {
            QuarterlyUpdateViewModel viewModel = new QuarterlyUpdateViewModel();

            return this.View("Edit", viewModel);
        }

        public ActionResult Edit(int quarterlyUpdateId)
        {
            QuarterlyUpdate quarterlyUpdate = this._quarterlyUpdatesService.GetQuarterlyUpdateById(quarterlyUpdateId);

            QuarterlyUpdateViewModel viewModel = new QuarterlyUpdateViewModel(quarterlyUpdate);

            return this.View("Edit", viewModel);
        }

        public ActionResult Save(QuarterlyUpdateViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                QuarterlyUpdate quarterlyUpdate = new QuarterlyUpdate();

                if (viewModel.QuarterlyUpdateId != 0)
                {
                    quarterlyUpdate = this._quarterlyUpdatesService.GetQuarterlyUpdateById(viewModel.QuarterlyUpdateId);
                }

                quarterlyUpdate.Text = viewModel.Text;
                quarterlyUpdate.DownloadLink = viewModel.DownloadLink;
                quarterlyUpdate.Month = viewModel.Month.Value;
                quarterlyUpdate.Year = viewModel.Year.Value;

                this._quarterlyUpdatesService.Save(quarterlyUpdate);

                return this.RedirectToRoute(AdminRoutes.QuarterlyUpdates.Index, new { saved = true });
            }

            return this.Edit(viewModel.QuarterlyUpdateId);
        }

        public ActionResult Delete(int quarterlyUpdateId)
        {
            this._quarterlyUpdatesService.Delete(quarterlyUpdateId);

            return this.RedirectToRoute(AdminRoutes.QuarterlyUpdates.Index, new { deleted = true });
        }
    }
}