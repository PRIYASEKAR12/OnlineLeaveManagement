using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    class UserLogin
    {
        int userId;
        int employeeId;
        string userName;
        string Password;
        public UserLogin(int userId,int employeeId,string userName,string Password)
        {
            this.userId = userId;
            this.employeeId = employeeId;
            this.userName = userName;
            this.Password = Password;
        }
    }
}
