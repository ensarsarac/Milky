using Milky.BusinessLayer.Abstract;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.BusinessLayer.Concrete
{
    public class TeamSocialMediaManager : ITeamSocialMediaService
    {
        private readonly ITeamSocialMediaDal _teamSocialMediaDal;

        public TeamSocialMediaManager(ITeamSocialMediaDal teamSocialMediaDal)
        {
            _teamSocialMediaDal = teamSocialMediaDal;
        }

        public void TDelete(int id)
        {
            _teamSocialMediaDal.Delete(id);
        }

        public TeamSocialMedia TGetById(int id)
        {
            return _teamSocialMediaDal.GetById(id);
        }

        public List<TeamSocialMedia> TGetList()
        {
            return _teamSocialMediaDal.GetList();
        }

        public List<TeamSocialMedia> TGetTeamSocialMediaByTeamId(int id)
        {
            return _teamSocialMediaDal.GetTeamSocialMediaByTeamId(id);
        }

        public void TInsert(TeamSocialMedia entity)
        {
            _teamSocialMediaDal.Insert(entity);
        }

        public void TUpdate(TeamSocialMedia entity)
        {
            _teamSocialMediaDal.Update(entity);
        }
    }
}
