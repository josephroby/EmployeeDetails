using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class EmployeeDetails
    {


        
        public static string EmployeeId, EmployeeName, EmployeePhonenumber, EmployeeEmail;


        static string message = "Enter the Employee details:";
        public static void setMessage(string msg)
        {
            message = msg;
        }



        public static string getMessage()
        {
            return message;
        }

    }

}


