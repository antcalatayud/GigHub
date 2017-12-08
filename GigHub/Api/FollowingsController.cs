using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (userId == dto.FolloweeId)
                return BadRequest("Can't follow your self");

            if (_context.
                Followings.
                Any(a => a.FollowerId == userId && a.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists");

            var follow = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(follow);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var follow = _context.Followings
                .SingleOrDefault(f => f.FolloweeId == id && f.FollowerId == userId);

            if (follow == null)
                return NotFound();

            _context.Followings.Remove(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
