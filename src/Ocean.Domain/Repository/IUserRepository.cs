using Ocean.Domain.Model.User.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Repository
{
   public interface IUserRepository : IRepository<User, string>
    {
    }
}
