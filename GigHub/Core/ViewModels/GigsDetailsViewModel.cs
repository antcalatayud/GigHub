﻿using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class GigsDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}