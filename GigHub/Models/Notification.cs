using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{

    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }

        private Notification()
        {
        }

        public Notification(Gig gig, NotificationType notificationType, DateTime? originalDateTime = null, string originalVenue = "")
        {
            if (gig == null) throw new ArgumentNullException("gig");

            Gig = gig;
            NotificationType = notificationType;
            DateTime = DateTime.Now;
            if (originalDateTime != null) OriginalDateTime = originalDateTime;
            if (originalVenue != "") OriginalVenue = originalVenue;
        }

    }
}