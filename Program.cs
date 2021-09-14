using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace demo
{
    class Program
    {
        public static SqlDbType EmployeeEmail { get; private set; }
        public static SqlDbType EmployeePhonenumber { get; private set; }

        static void Main(string[] args)
        {

            var employee = new Validatedetails();
            employee.ValidateEmployeeId();
            employee.ValidateEmployeeName();
            employee.ValidateEmployeeEmail();
            employee.ValidateEmployeePhoneNumber();
            employee.ValidateDateOfBirth();
            employee.connectTODb();
            employee.ValidateEmployeeprintdetails();
            Console.ReadLine();
            
            }


        }
    }
