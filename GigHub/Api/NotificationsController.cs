﻿using AutoMapper.QueryableExtensions;
using GigHub.App_Start;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly MappingProfile mappingProfile; 

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
            mappingProfile = new MappingProfile();
        }
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();            

            return notifications.Select(mappingProfile.mapper.Map<Notification, NotificationDto>);
        }
    }
}
