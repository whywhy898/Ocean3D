using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.User.Event
{
   public class RegistedUserEvent: Core.Events.Event
    {
       public string Id { get; set; }

       public string AccountName { get; set; }

       public string PassWord { get; set; }

       public string Tel { get; set; }

       public RegistedUserEvent(string id,string accountName, string password, string telNum)
       {
            Id = Id;
            AccountName = accountName;
            PassWord = password;
            Tel = telNum;
       }

    }
}
