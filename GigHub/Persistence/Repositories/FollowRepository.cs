using GigHub.Core.Models;
using GigHub.Core.Repositories;
using GigHub.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Following> GetUserFollowees(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .ToList();
        }

        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == artistId);
        }

        public IEnumerable<ApplicationUser> GetUserFolloweesWithName(string userId)
        {
            return _context
                .Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }
    }
}