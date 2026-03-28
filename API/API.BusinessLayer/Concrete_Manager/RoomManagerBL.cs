using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class RoomManagerBL : IRoomService
    {
       private readonly IRoomDAL roomdal;

        public RoomManagerBL(IRoomDAL roomdal)
        {
            this.roomdal = roomdal;
        }

        public List<Room> GetAllS()
        {
            return roomdal.GetListAll();
        }

        public Room Getbyid(int id)
        {
            return roomdal.GetByID(id);
        }

        public void SDelete(Room s)
        {
            roomdal.Delete(s);
        }

        public void SInsert(Room s)
        {
            roomdal.Insert(s);
        }

        public void SUpdate(Room s)
        {
            roomdal.Update(s);
        }
    }
}
