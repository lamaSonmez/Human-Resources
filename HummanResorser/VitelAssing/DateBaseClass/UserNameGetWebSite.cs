using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HummanResorser
{
  public  class UserNameGetWebSite : IaddName
    {
        public int id { private set; get; }
        public string username { private set; get; }
        public string password { private set; get; }
        public string name { private set; get; }
        public UserNameGetWebSite (int id , string username , string pawssword , string name)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.name = name;
        }

        public string RetunNameString()
        {
            return name;
        }

        public int RetunIdNumber()
        {
            return id;
        }
    }
}
