using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.JwtBreare
{
   public class JWTConfig
    {
        /// <summary>
        /// Token发布者
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Token接受者
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Token过期时间
        /// </summary>
        public int AccessTokenExpiresMinutes { get; set; }
        /// <summary>
        /// refreshToken过期时间
        /// </summary>
        public int RefreshTokenExpiresMinutes { get; set; }
        /// <summary>
        /// 签名秘钥 必须16位
        /// </summary>
        public string SigningKey { get; set; }


    }
}
