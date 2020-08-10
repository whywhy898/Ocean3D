using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Application.ViewModel
{
   public class RegisterUserDto
    {
        public string AccountName { get; set; }

        public string PassWord { get; set; }

        public string AgainPassWord { get; set; }

        public string TelNum { get; set; }
    }
}
