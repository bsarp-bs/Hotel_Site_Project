using API.BusinessLayer.Service;
using API.DataAccessLayer.Abstract;
using API.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.BusinessLayer.Concrete_Manager
{
    public class TeamManagerBL : ITeamService
    {
        private readonly ITeamDAL team;

        public TeamManagerBL(ITeamDAL _team)
        {
            this.team = _team;
        }

        public List<Team> GetAllS()
        {
            return team.GetListAll();
        }

        public Team Getbyid(int id)
        {
            return team.GetByID(id);
        }

        public void SDelete(Team s)
        {
            team.Delete(s);
        }

        public void SInsert(Team s)
        {
            team.Insert(s);
        }

        public void SUpdate(Team s)
        {
            team.Update(s);
        }
    }
}
