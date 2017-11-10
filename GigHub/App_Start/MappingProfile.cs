using AutoMapper;
using GigHub.Dtos;
using GigHub.Models;

namespace GigHub.App_Start
{
    public class MappingProfile : Profile
    {
        public IMapper mapper { get; set; }

        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Genre, GenreDto>();
                cfg.CreateMap<Gig, GigDto>();
                cfg.CreateMap<Notification, NotificationDto>();
            });

            mapper = config.CreateMapper();
        }
    }
}