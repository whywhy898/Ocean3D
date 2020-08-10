using Ocean.Domain.Model.User.Entity;
using Ocean.Domain.Repository;
using Ocean.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.Repositorys
{
   public class UserRepository : Repository<User, string>, IUserRepository
    {
        public UserRepository(EFDbContext context) : base(context)
        {

        }
    }
}
