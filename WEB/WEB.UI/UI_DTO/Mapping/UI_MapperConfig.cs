using API.EntityLayer.Concrete;
using AutoMapper;
using WEB_UI.UI_DTO.BookingDTOs;
using WEB_UI.UI_DTO.DutyDTOs;
using WEB_UI.UI_DTO.LoginDTOs;
using WEB_UI.UI_DTO.ReffDTOs;
using WEB_UI.UI_DTO.RegisterDTOs;
using WEB_UI.UI_DTO.RoomDTOs;
using WEB_UI.UI_DTO.SubscribeDTOs;
using WEB_UI.UI_DTO.TeamDTOs;
using WEB_UI.UI_DTO.ContactDTOs;

namespace WEB_UI.UI_DTO.Mapping
{
    public class UI_MapperConfig : Profile
    {
        public UI_MapperConfig()
        { 
            CreateMap<InsertDutyDto,Duty>().ReverseMap();
            CreateMap<ViewDutyDto, Duty>().ReverseMap();
            CreateMap<UpdateDutyDto, Duty>().ReverseMap();

            CreateMap<InsertRegisterDto, AppUser>().ReverseMap();

            CreateMap<LoginDto, AppUser>().ReverseMap();

            CreateMap<ReffDto, Reff>().ReverseMap();

            CreateMap<ViewRoomDto, Room>().ReverseMap();
            CreateMap<InsertRoomDto, Room>().ReverseMap();

            CreateMap<TeamDto, Team>().ReverseMap();

            CreateMap<InsertSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<InsertBookingDto,Booking>().ReverseMap();
            CreateMap<ViewBookingDto, Booking>().ReverseMap();

            CreateMap<InsertContactDto, Contact>().ReverseMap();
            CreateMap<ViewContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();

        }
    }
}
