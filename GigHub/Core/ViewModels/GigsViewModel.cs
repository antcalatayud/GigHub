﻿using GigHub.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub.Core.ViewModels
{
    public class GigsViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get; internal set; }
        public ILookup<string, Following> Follows { get; internal set; }
    }
}