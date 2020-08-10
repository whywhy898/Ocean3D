using Ocean.Domain.Core.SeedWork;
using Ocean.Domain.Model.Relation.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.Role.Entity
{
   public class Role:BaseEntity<string>,IAggregateRoot
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get;private set; }

        /// <summary>
        /// 关联角色
        /// </summary>
        public ICollection<UserRoleRelation> userRoleRelations { get; private set; }

        public Role() { }
        public Role(string roleName)
        {
            RoleName = roleName;
        }
    }
}
