using API.EntityLayer.Concrete;
using AutoMapper;
using WEB_UI.UI_DTO.DutyDTOs;
using WEB_UI.UI_DTO.LoginDTOs;
using WEB_UI.UI_DTO.RegisterDTOs;

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
        }
    }
}
