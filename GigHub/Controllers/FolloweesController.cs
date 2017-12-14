using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public FolloweesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var followees = _unitOfWork.Follow.GetUserFolloweesWithName(userId);

            return View(followees);
        }
    }
}