using System.Collections.Generic;
using System.Web.Mvc;
using VideoRental.ViewModel.Views;
using VideoRental.Web.DbContext;

namespace VideoRental.Web.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var list = new List<RoleView>();
            var request = db.Roles;
            foreach (var item in request)
            {
                var model = new RoleView()
                {
                    Id = item.Id,
                    Name = item.Name
                };

                list.Add(model);
            }

            return View(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}