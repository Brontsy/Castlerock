using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Nhibernate;
using Portal.Membership;
using Portal.Membership.Models;
using Portal.Web.Areas.Membership.Extensions;
using Portal.Web.Areas.Membership.Models;
using Portal.Web.Attributes;
using Portal.Web.Controllers;
using Portal.Websites.Interfaces;
using Common.Exceptions;

namespace Portal.Web.Areas.Membership.Controllers
{
    [AdministratorFilter]
    public class MembershipController : PortalBaseController
    {
        private IMembershipService _membershipService = null;
        private IExceptionManager _exceptionManager = null;

        public MembershipController(IWebsite website, IMembershipService membershipService, IExceptionManager exceptionManager)
            : base(website)
        {
            this._membershipService = membershipService;
            this._exceptionManager = exceptionManager;
        }

        /// <summary>
        /// Renders all the members onto the page. The user can then view / edit them from here
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IList<Member> members = this._membershipService.GetAllMembers().OrderBy(o => o.Username).ToList();

            MembershipPageViewModel viewModel = new MembershipPageViewModel(this.Website, members);

            return View("Index", viewModel);
        }

        /// <summary>
        /// Renders a page to create a new meber
        /// </summary>
        /// <returns></returns>
        [ImportModelStateFromTempData]
        public ActionResult New()
        {
            return this.NewMember(new Member());
        }

        /// <summary>
        /// Internal helper method to render the "New Member" page
        /// </summary>
        /// <param name="member">the member to render inside the form</param>
        /// <returns></returns>
        private ActionResult NewMember(Member member)
        {
            MembershipPageViewModel viewModel = new MembershipPageViewModel(this.Website, member);

            return View("New", viewModel);
        }

        /// <summary>
        /// Renders the edit a member page
        /// </summary>
        /// <param name="member">the memebr that will be edited</param>
        /// <returns></returns>
        [ImportModelStateFromTempData]
        public ActionResult Edit(Member member)
        {
            MembershipPageViewModel viewModel = new MembershipPageViewModel(this.Website, member);

            return View("Edit", viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
        public ActionResult ChangePassword(Member member, ChangePasswordViewModel changePassword)
        {
            if (this.ModelState.IsValid)
            {
                this._membershipService.ChangePassword(member, changePassword.Password);

                this.ConfirmationMessage = "Password has been changed.";

                return this.RedirectToRoute(MembershipAreaRegistration.MembershipRouteUrl);
            }

            return this.RedirectToRoute(MembershipAreaRegistration.MembershipEditRouteUrl);
        }

        [ExportModelStateToTempData]
        public ActionResult Save(MemberViewModel memberViewModel, Member member)
        {
                if (this.ModelState.IsValid)
            {
                try
                {
                    // Copy the properties from the view model to our member object
                    member = memberViewModel.ToMember(member);

                    // Save the member back to the database
                    this._membershipService.SaveMember(member);

                    this.ConfirmationMessage = "Member was saved.";

                    return this.RedirectToRoute(MembershipAreaRegistration.MembershipRouteUrl);
                }
                catch (Exception exception)
                {
                    exception.Data.Add("Member Id", member.Id);
                    exception.Data.Add("Username", member.Username);
                    this._exceptionManager.LogException(exception, "Unable to save Member");

                    this.ErrorMessage = "There was a problem saving. Please try again";
                }
            }

            if (member.Id == 0)
            {
                return this.RedirectToRoute(MembershipAreaRegistration.MembershipNewRouteUrl);
            }

            // If there was a problem then return the edit view
            return this.RedirectToRoute(MembershipAreaRegistration.MembershipEditRouteUrl);
        }

    }
}
