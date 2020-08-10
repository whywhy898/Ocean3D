using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ocean.Application.ViewModel
{
  public  class LoginUserDto
    {
        [Required]
        public string Account { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
