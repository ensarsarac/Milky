using Microsoft.EntityFrameworkCore;
using Milky.DataAccessLayer.Abstract;
using Milky.DataAccessLayer.Concrete;
using Milky.DataAccessLayer.Repositories;
using Milky.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milky.DataAccessLayer.EntityFramework
{
    public class TeamSocialMediaRepository : GenericRepositories<TeamSocialMedia>, ITeamSocialMediaDal
    {
        private readonly MilkyContext _context;
        public TeamSocialMediaRepository(MilkyContext context):base(context)
        {
            _context = context;
        }

        public List<TeamSocialMedia> GetTeamSocialMediaByTeamId(int id)
        {
            var values = _context.TeamSocialMedias.Where(x=>x.TeamId == id).ToList();
            return values;
        }
    }
}
