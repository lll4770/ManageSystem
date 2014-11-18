using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_gangEntity
{
    public class UserInfo
    {
        public int userID { get; set; }
        public string UserNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string NickName { get; set; }
        public DateTime CreateDate { get; set; }
        public int StatusID { get; set; }
        public string Remark { get; set; }
    }
}
