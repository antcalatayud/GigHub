using GigHub.Core.Repositories;
using GigHub.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendance { get; }
        IFollowRepository Follow { get; }
        IGenreRepository Genre { get; }
        IGigRepository Gigs { get; }

        void Complete();
    }
}