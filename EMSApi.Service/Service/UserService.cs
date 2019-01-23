using EMSApi.Domain;
using EMSApi.Entity;
using EMSApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EMSApi.Service.Service
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            var query = from users in _context.Users
                        select new User {
                            UserID = users.UserID,
                            UserName = users.UserName,
                            Manager = users.Manager
                        };

            return query.ToList();
        }
    }
}
