using EMSApi.Entity;
using EMSApi.Entity.PlainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Service.IService
{
    public interface IBuildService
    {
        List<BuildInfo> GetAllBuilds();

        List<BuildSimpleInfo> GetAllSimpleBuild();

        List<UserBuildRelationship> GetBuildsByUser(string userName);

        BuildInfo GetBuildInfo(string buildid);
    }
}
