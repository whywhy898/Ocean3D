using Ocean.Domain.Core.SeedWork;
using Ocean.Domain.Model.Relation.Entity;
using Ocean.Domain.Model.User.Entity;
using Ocean.Domain.Model.User.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.User.Entity
{
   public class User:BaseEntity<string> , IAggregateRoot
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; private set; }
        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; private set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNumber { get; private set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; private set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmadilAddress { get;private set; }
        /// <summary>
        /// 个人地址信息
        /// </summary>
        public Address address { get; private set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; private set; } = true;
        /// <summary>
        /// 关联角色
        /// </summary>
        public ICollection<UserRoleRelation> userRoleRelations { get; private set; }

        public User() { }

        public User(string id,string accountName,string passWord,string tel) {

            Id = id;
            AccountName = accountName;
            PassWord = passWord;
            Tel = tel;
            Nick = $"新用户{this.GetHashCode()}";

            RegisterUser();
        }

        public void RegisterUser()
        {
            var registedUserEvent = new RegistedUserEvent(Id, AccountName, PassWord, Tel);
            this.AddDomainEvent(registedUserEvent);
        }
    }
}
