using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.CORE.Dto
{
   public class CreateUserDto
    {
        public string UserName { get; set; }
       
        public string Email { get; set; }
        public string Password { get; set; }

        public int GrupId { get; set; }
       
    }
}
