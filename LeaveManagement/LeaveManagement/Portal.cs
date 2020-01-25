using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement
{
    class Portal
    {
        public enum selectChoice { admin = 1, exit }
        public void Login()
        {
            do
            {
                Console.WriteLine("Enter Your Choice \n 1.admin\n 2.login\n 3.Exit");
                int readChoice = Int32.Parse(Console.ReadLine());
                selectChoice myChoice = (selectChoice)readChoice;
                switch (myChoice)
                {
                    case selectChoice.admin:
                        AdminAuthority admin = new AdminAuthority();
                        admin.adminLogin();
                        break;
                    case selectChoice.exit:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            while (true);
        }
    }
        
}
