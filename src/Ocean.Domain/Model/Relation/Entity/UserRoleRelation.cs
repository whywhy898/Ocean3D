using Ocean.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.Relation.Entity
{
   public class UserRoleRelation:BaseEntity<string>
    {
        public string UserId { get;private set; }

        public string RoleId { get; private set; }

        public Role.Entity.Role RoleInfo { get; private set; }

        public User.Entity.User UserInfo { get; private set; }

    }
}
