using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public GigRepository Gigs { get; private set; }
        public AttendanceRepository Attendance { get; private set; }
        public FollowRepository Follow { get; private set; }
        public GenreRepository Genre { get; private set; }

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