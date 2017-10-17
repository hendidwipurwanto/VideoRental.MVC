using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using VideoRental.Service.Interfaces;
using VideoRental.ViewModel.Views;
using VideoRental.Web.DbContext;
using System.Collections.Generic;
using VideoRental.Web.Resolver;

namespace VideoRental.Web.Controllers
{
    [LoggedAs(Roles = "Admin")]
    public class UserDetailController : Controller
    {
        private readonly IUserDetailService _userDetailService;
        private readonly IGenderService _genderService;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context = new ApplicationDbContext();

        public UserDetailController(IUserDetailService userDetailService, IGenderService genderService,
            ApplicationUserManager userManager)
        {
            _userDetailService = userDetailService;
            _genderService = genderService;
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var list = new List<UserDetailView>();
            var userDetailList = _userDetailService.GetUserDetailViewList();
            foreach (var item in userDetailList)
            {
                var userRole = GetUserRoleByUserDetailId(item.Id);
                item.UserRole = userRole;
                list.Add(item);
            }

            return View(list);
        }

        public ActionResult Edit(string id)
        {
            var userDetailView = new UserDetailView();
            var request = _userDetailService.GetById(id);
            Mapper.Map(request, userDetailView);
           
            var userRole = GetUserRoleByUserDetailId(request.Id); 

            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "Name", request.GenderId);
            ViewBag.UserRole = new SelectList(_context.Roles, "Name", "Name", userRole);

            return View(userDetailView);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDetailView userDetailView)
        {
            string userRole;

            if (ModelState.IsValid)
            {
                var userdDetail = _userDetailService.UpdateUserDetailView(userDetailView);

                var aspNetUserId = _context.Users.Where(w => w.UserDetailId == userDetailView.Id).Select(s => s.Id).FirstOrDefault();
                userRole = GetUserRoleByAspNetUserId(aspNetUserId);

                await this.UserManager.RemoveFromRoleAsync(aspNetUserId, userRole);

                await this.UserManager.AddToRoleAsync(aspNetUserId, userDetailView.UserRole);

                return RedirectToAction("Index");
            }

            var request = _userDetailService.GetById(userDetailView.Id);
            userRole = GetUserRoleByUserDetailId(request.Id);
            ViewBag.GenderId = new SelectList(_genderService.GetAll(), "Id", "Name", request.GenderId);
            ViewBag.UserRole = new SelectList(_context.Roles, "Name", "Name", userRole);
            return View(userDetailView);
        }

        private string GetUserRoleByAspNetUserId(string aspNetUserId)
        {
            var roleId = _context.Users.Where(w => w.Id == aspNetUserId).Select(s => s.Roles.FirstOrDefault()).FirstOrDefault().RoleId;
            var userRole = _context.Roles.Find(roleId).Name;

            return userRole;
        }

        private string GetUserRoleByUserDetailId(string userDetailId)
        {
            var aspNetUserId = _context.Users.Where(w => w.UserDetailId == userDetailId).Select(s => s.Id).FirstOrDefault();
            var roleId = _context.Users.Where(w => w.Id == aspNetUserId).Select(s => s.Roles.FirstOrDefault()).FirstOrDefault().RoleId;
            var userRole = _context.Roles.Find(roleId).Name;

            return userRole;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}