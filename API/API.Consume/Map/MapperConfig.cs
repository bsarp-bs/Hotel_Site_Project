using API.DtoLayer;
using API.EntityLayer.Concrete;
using AutoMapper;

namespace API.Consume.Map
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            /*  
                CreateMap<RoomDTO, Room>();
                CreateMap<Room,RoomDTO>();
            */

            CreateMap<RoomDTO, Room>().ReverseMap();
        }
    }
}
