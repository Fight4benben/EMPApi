using EMSApi.Domain;
using EMSApi.Entity;
using EMSApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EMSApi.Entity.PlainClass;

namespace EMSApi.Service.Service
{
    public class BuildService : IBuildService
    {
        private ApplicationDbContext _context;

        public BuildService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BuildInfo> GetAllBuilds()
        {
            var query = from builds in _context.Builds
                        select new BuildInfo
                        {
                            BuildId = builds.BuildId,
                            BuildName = builds.BuildName,
                            BuildLong = builds.BuildLong,
                            BuildLat = builds.BuildLat,
                            BuildAddr = builds.BuildAddr
                        };

            return query.ToList();
        }

        public BuildInfo GetBuildInfo(string buildid)
        {
            var query = from builds in _context.Builds
                        where builds.BuildId == buildid
                        select new BuildInfo
                        {
                            BuildId = builds.BuildId,
                            BuildName = builds.BuildName,
                            BuildAddr = builds.BuildAddr,
                            BuildLat = builds.BuildLat,
                            BuildLong = builds.BuildLong
                        };
            List<BuildInfo> buildlist = query.ToList();
            if (buildlist.Count > 0)
                return buildlist.First();
            else
                return null;
        }

        public List<BuildSimpleInfo> GetAllSimpleBuild()
        {
            var query = from builds in _context.Builds
                        select new BuildSimpleInfo
                        {
                            BuildId = builds.BuildId,
                            BuildName = builds.BuildName
                        };

            return query.ToList();
        }

        public List<UserBuildRelationship> GetBuildsByUser(string userName)
        {
            var query = from user_buildings in _context.UserBuilds
                        join user in _context.Users on user_buildings.UserName equals user.UserName
                        join build in _context.Builds on user_buildings.BuildId equals build.BuildId
                        where user_buildings.UserName == userName
                        select new UserBuildRelationship{
                            UserId = user.UserID,
                            UserName = user.UserName,
                            BuildId = build.BuildId,
                            BuildName = build.BuildName
                        };

                return query.ToList();
        }
    }
}
