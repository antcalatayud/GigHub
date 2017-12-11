using GigHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowRepository
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
    }
}