using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<Following> GetUserFollowees(string userId);
    }
}