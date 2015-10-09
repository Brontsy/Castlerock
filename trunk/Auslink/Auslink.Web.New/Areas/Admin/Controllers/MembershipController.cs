using Auslink.Membership.Models;
using Auslink.Membership.Services;
using Auslink.Web.New.Areas.Admin.Models.Membership;
using Auslink.Web.New.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auslink.Web.New.Areas.Admin.Controllers
{
    [AdminAttribute]
    public class MembershipController : Controller
    {
        private IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            this._membershipService = membershipService;
        }

        // GET: Admin/Membership
        public ActionResult Index()
        {
            IList<Member> members = this._membershipService.GetMembers();

            MemberListViewModel viewModel = new MemberListViewModel(members);

            return View("Index", viewModel);
        }

        public ActionResult Edit(int memberId, bool? saved = null)
        {
            Member member = this._membershipService.GetMemberById(memberId);

            MemberViewModel viewModel = new MemberViewModel(member);

            ViewBag.Saved = saved;

            return this.View("Edit", viewModel);
        }


        public ActionResult Add()
        {
            MemberViewModel viewModel = new MemberViewModel();

            return this.View("Edit", viewModel);
        }

        public ActionResult Save(MemberViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Member member = this._membershipService.GetMemberById(viewModel.MemberId);

                if (member == null)
                {
                    member = new Member();
                    member.UpdatePassword(viewModel.Password.Password);
                }

                member.FirstName = viewModel.FirstName;
                member.LastName = viewModel.LastName;
                member.Company = viewModel.Company;
                member.Phone = viewModel.Phone;
                member.Email = viewModel.Email;
                member.Username = viewModel.Username;
                member.Roles = viewModel.SelectedRoles;

                this._membershipService.SaveMember(member);

                return this.RedirectToRoute(AdminRoutes.Membership.Edit, new { saved = true });
            }

            return this.Edit(viewModel.MemberId);
        }

        public ActionResult ChangePassword(PasswordViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                Member member = this._membershipService.GetMemberById(viewModel.MemberId);

                member.UpdatePassword(viewModel.Password);

                this._membershipService.SaveMember(member);

                return this.RedirectToRoute(AdminRoutes.Membership.Edit, new { saved = true });
            }

            return this.Edit(viewModel.MemberId);
        }

        public ActionResult LoggedInMember()
        {
            return this.Content("luke.bronts");
        }
    }
}