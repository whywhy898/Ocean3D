using Ocean.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.User.Entity
{
    /// <summary>
    /// 用户地址信息 值对象
    /// </summary>
   public class Address:ValueObject
    {
        public string Province { get;private set; }

        public string City { get; private set; }

        public string Location { get; private set; }

        public Address(string province,string city,string location)
        {
            Province = province;
            City = city;
            Location = location;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Province;
            yield return City;
            yield return Location;
        }
    }
}
