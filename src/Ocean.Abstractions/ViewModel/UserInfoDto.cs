using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
   public class UserInfoDto
    {
        public string Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        public string QQNumber { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmadilAddress { get; set; }
    }
}
