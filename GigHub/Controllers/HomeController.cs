using GigHub.Core.ViewModels;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _unitOfWork.Gigs.GetUpcomingGigs();

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = _unitOfWork.Gigs.FilterGigs(upcomingGigs, query);
            }

            string userId = User.Identity.GetUserId();

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = _unitOfWork.Attendance.GetFutureAttendances(userId).ToLookup(a => a.GigId),
                Follows = _unitOfWork.Follow.GetUserFollowees(userId).ToLookup(f => f.FolloweeId)
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}