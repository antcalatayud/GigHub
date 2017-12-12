using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _contex;

        public FolloweesController()
        {
            _contex = new ApplicationDbContext();
        }


        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var followees = _contex
                .Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(followees);
        }
    }
}