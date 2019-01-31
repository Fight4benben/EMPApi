using EMSApi.Entity.PlainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Service.IService
{
    public interface IEnergyViewService
    {
        EnergyViewModel GetEnergyView(string buildid, string energyCode, DateTime date);
    }
}
