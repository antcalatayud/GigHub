using GigHub.Core;
using GigHub.Core.Repositories;
using GigHub.Persistence.Repositories;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendance { get; private set; }
        public IFollowRepository Follow { get; private set; }
        public IGenreRepository Genre { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(_context);
            Attendance = new AttendanceRepository(_context);
            Follow = new FollowRepository(_context);
            Genre = new GenreRepository(_context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}