using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace demo
{
    public class Employee
    {
        public String EmployeeId;
        public String EmployeeName;
        public String EmployeeEmail;
        public String EmployeePhoneNumber;
        public int EmployeeAge;


    }
    public class Validatedetails : Employee
    {
        public void ValidateEmployeeId()
        {
            String employeeId;
            var flag = 0;
            //var scanner = "Inputs";
            Console.WriteLine("Enter Employee ID : ");
            employeeId = Console.ReadLine();
            var str1 = "0000";
            while (flag == 0)
            {
                var length = employeeId.Length;
                var str2 = employeeId.Substring(3);
                if (length == 7 && (employeeId.StartsWith("ace") || employeeId.StartsWith("ACE") == true))
                {
                    flag = 1;
                    EmployeeId = employeeId;
                    for (var i = 3; i < 7; i++)
                    {
                        if (!char.IsDigit(employeeId[i]))
                        {
                            flag = 1;
                            break;
                        }
                    }
                    Console.WriteLine("Employee Id :" + EmployeeId);
                }
                else
                { flag = 0; }
                if (flag == 0 || str1.Equals(str2) == true)
                {
                    Console.WriteLine("Invalid Employee ID; ID should start with ACE followed by 4 digits");
                    Console.WriteLine("Enter Valid Employee ID : ");
                    employeeId = Console.ReadLine();
                }
            }
        }
        public void ValidateEmployeeName()
        {
            String EmployeeName1;
            var flag = 0;
            while (flag == 0)
            {
                Console.WriteLine("Enter Employee Name :");
                EmployeeName1 = Console.ReadLine();
                var length = EmployeeName1.Length;
                String nameasuppercase = EmployeeName1.ToUpper();
                char[] data = nameasuppercase.ToCharArray();
                for (int k = 0; k < length; k++)
                {
                    int asciinum = (int)data[k];
                    if (asciinum != 32)
                    {
                        if (asciinum < 65 || asciinum > 90)
                        {
                            flag = 0;
                            Console.WriteLine("ENTER ONLY ALPHABETS");
                            break;
                        }
                        else
                            flag = 1;

                    }

                }
                if (flag == 1)
                {
                    EmployeeName = EmployeeName1;
                    break;
                }

            }
        }
        public void ValidateEmployeeEmail()
        {
            String Email;
            var flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("Enter Email ID:");
                Email = Console.ReadLine();
                Regex regex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z]+(.com|.COM)$");
                bool isValidEmail = regex.IsMatch(Email);

                if (isValidEmail)
                {

                    flag = 0;
                    EmployeeEmail = Email;
                    break;
                }
                else
                {
                    flag = 1;
                    Console.WriteLine("INVALID MAIL ID...eg-robert@(any domain).com");
                }
            }
        }
        public void ValidateEmployeePhoneNumber()
        {
            String PhoneNumber;
            var flag = 0;
            while (flag == 0)
            {
                Console.WriteLine("Enter Mobile Number:");
                PhoneNumber = Console.ReadLine();
                Regex regex = new Regex("(91)?[5-9][0-9]{9}$");
                bool isValidPhoneNumber = regex.IsMatch(PhoneNumber);
                if ((isValidPhoneNumber) && (PhoneNumber.Length == 10))
                {
                    flag = 1;
                    EmployeePhoneNumber = PhoneNumber;
                    break;
                }
                else
                {
                    flag = 0;
                    Console.WriteLine("INVALID NUMBER. ENTER 10 DIGIT NUMBER STARTING FROM 5-9 ");
                }
            }

        }
        public void ValidateDateOfBirth()
        {
            var flag = 0;

            while (flag != 1)
            {
                Console.Write("Enter date of birth in YYYY-MM-DD or DD-MM-YYYY format: ");
                DateTime bday = DateTime.Parse(Console.ReadLine());
                TimeSpan diff = DateTime.Now.Date - bday.Date;
                DateTime zeroDate = new DateTime(1, 1, 1);
                int age = (zeroDate + diff).Year - 1;
                if (age < 18 || age > 60)
                {
                    Console.WriteLine("Invalid Age - Age must be between 18-60");
                }
                else
                {
                    Console.WriteLine("Valid Age: {0}", age);
                    EmployeeAge = age;
                    flag = 1;
                    break;
                }
            }
        }
        public void ValidateEmployeeprintdetails()
        {
            Console.WriteLine("\n\nPRINTING THE DETAILS OF EMPLOYEE ");
            Console.WriteLine("Employee Name :" + EmployeeName);
            Console.WriteLine("Employee Id :" + EmployeeId);
            Console.WriteLine("Employee PhoneNumber :" + EmployeePhoneNumber);
            Console.WriteLine("Employee Email :" + EmployeeEmail);
            Console.WriteLine("Employee Age :" + EmployeeAge);

            String[] DetailsInArray = { "Employee ID :" + EmployeeId, "Employee Name : " + EmployeeName, "Employee Contact No. : " + EmployeePhoneNumber, "Employee MailID  : " + EmployeeEmail, "Employee Age : " + EmployeeAge };
            Console.WriteLine("\n\nDETAILS ARE ADDED TO ARRAY");
            foreach (var details in DetailsInArray)
                Console.WriteLine(details);
            ArrayList list;
            list = new ArrayList();
            list.Add(EmployeeId);
            list.Add(EmployeeName);
            list.Add(EmployeeEmail);
            list.Add(EmployeePhoneNumber);
            list.Add(EmployeeAge);
            foreach (var details in list)
                Console.WriteLine(details);
        }
        public void connectTODb()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=rvskch573lt;Database=Project;Trusted_Connection=true";
                conn.Open();
                Console.WriteLine("INSERT INTO command");

                SqlCommand insertCommand = new SqlCommand("INSERT INTO connection (EmployeeId,EmployeeName,EmployeeEmail,EmployeePhoneNumber,EmployeeAge) VALUES (@0,@1,@2,@3,@4)", conn);
                insertCommand.Parameters.Add(new SqlParameter("0", EmployeeId));
                insertCommand.Parameters.Add(new SqlParameter("1", EmployeeName));
                insertCommand.Parameters.Add(new SqlParameter("2", EmployeeEmail));
                insertCommand.Parameters.Add(new SqlParameter("3", EmployeePhoneNumber));
                insertCommand.Parameters.Add(new SqlParameter("4", EmployeeAge));
                Console.WriteLine("Commands executed! Total rows affected are " + insertCommand.ExecuteNonQuery());
                Console.WriteLine("Done! Press enter to move to the next step");
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}


