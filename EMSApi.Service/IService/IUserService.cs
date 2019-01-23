using EMSApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMSApi.Service.IService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}
