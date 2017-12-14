using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<Following> GetUserFollowees(string userId);
        IEnumerable<ApplicationUser> GetUserFolloweesWithName(string userId);
    }
}