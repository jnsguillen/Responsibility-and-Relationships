using System;
using System.Data.SqlClient;


namespace DataLayer
{
    public class SqlData
    {
        public static string connectionString
            = "Data Source = DESKTOP-U692M88; Initial Catalog = ELMS; Integrated Security= True;";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        //public static void Connect()
        //{
        //  sqlConnection.Open();
        //}

        public static void ShowRecords()
        {
            SqlCommand selectData;

            // Create the sql command
            selectData = sqlConnection.CreateCommand();

            // Declare the sript of sql command
            selectData.CommandText = "SELECT EmployeeName, EmployeeAge, EmployeeAddress, VacationAvailable, SickLeaveAvailable, UnpaidLeaveAvailable, WorkFromHomeAvailable FROM dbo.EmployeeRecords";
            sqlConnection.Open();
            // Declare a reader, through which we will read the data.
            SqlDataReader rdr = selectData.ExecuteReader();

            // Read the data
            while (rdr.Read())
            {
                string empName = (string)rdr["EmployeeName"];
                int empAge = (int)rdr["EmployeeAge"];
                string empAddress = (string)rdr["EmployeeAddress"];
                int vacationAvail = (int)rdr["VacationAvailable"];
                int sickleaveAvail = (int)rdr["SickLeaveAvailable"];
                int unpaidleaveAvail = (int)rdr["UnpaidLeaveAvailable"];
                int workfromhomeAvail = (int)rdr["WorkFromHomeAvailable"];


                // Print the data.
                Console.WriteLine("Employee Name: " + empName + "\nAge: " + empAge + "\nAddress: " + empAddress + "\nVacations Available (out of 28): " + vacationAvail + "\nSick Leave Available (out of 30): " + sickleaveAvail + "\nUnpaid Leave Available (out of 365): " + unpaidleaveAvail + "\nWork from Home Available(out of 30): " + workfromhomeAvail + "\n \n \n");
            }

            rdr.Close();
            sqlConnection.Close();
        }




            public static void InputRecord()
        {

            sqlConnection.Open();
            var InputStatement = "INSERT INTO dbo.PendingRequests " +
                    "(EmployeeName, EmployeeAge, EmployeeAddress, Typeofleave, DateRequested) " +
                    "VALUES (@EmployeeName, @EmployeeAge, @EmployeeAddress, @TypeofLeave, @DateRequested)";

            Console.WriteLine("To file a Leave Request, kindly answer the following: ");

            Console.WriteLine("Name: ");
            string EmployeeName = Console.ReadLine();

            Console.WriteLine("Age: ");
            int EmployeeAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Address: ");
            string EmployeeAddress = Console.ReadLine();

            int TypeofLeave;
            Console.Write("Choose which type of leave you will request: ");
            Console.WriteLine("\n1: Vacation \n2. Sick Leave \n3: Unpaid Leave \n4: Work from home");
            TypeofLeave = Convert.ToInt32(Console.ReadLine());

            switch (TypeofLeave)
            {
                case 1:
                    Console.WriteLine("Vacation"); 
                    break;

                case 2:
                    Console.WriteLine("Sick Leave");
                    break;

                case 3:
                    Console.WriteLine("Unpaid Leave"); 
                    break;

                case 4:
                    Console.WriteLine("Work from Home"); 
                    break;
            }
            Console.WriteLine("Date Requested: " + DateTime.Now);
            string DateRequested=Console.ReadLine();
            
                SqlCommand inputCommand = new SqlCommand(InputStatement, sqlConnection);
                inputCommand.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                inputCommand.Parameters.AddWithValue("@EmployeeAge", EmployeeAge);
                inputCommand.Parameters.AddWithValue("@EmployeeAddress", EmployeeAddress);
                inputCommand.Parameters.AddWithValue("@TypeofLeave", TypeofLeave);
                inputCommand.Parameters.AddWithValue("@DateRequested", DateRequested);
              
                inputCommand.ExecuteNonQuery();
                sqlConnection.Close();

                Console.WriteLine("Successfully recorded");
            }

        public static void ViewRequests()
        {
            SqlCommand selectData;

            // Create the sql command
            selectData = sqlConnection.CreateCommand();

            // Declare the sript of sql command
            selectData.CommandText = "SELECT EmployeeName, EmployeeAge, EmployeeAddress, TypeofLeave, DateRequested FROM dbo.PendingRequests";
            sqlConnection.Open();
            // Declare a reader, through which we will read the data.
            SqlDataReader rdr = selectData.ExecuteReader();

            // Read the data
            while (rdr.Read())
            {
                string eName = (string)rdr["EmployeeName"];
                int eAge = (int)rdr["EmployeeAge"];
                string eAddress = (string)rdr["EmployeeAddress"];
                string toleave = (string)rdr["TypeofLeave"];
                string datereq = (string)rdr["DateRequested"];

                // Print the data.
                Console.WriteLine("Employee Name: " + eName + "\nAge: " + eAge + "\nAddress: " + eAddress + "\nType of Leave Requested: " + toleave + "\nDate Requested: " + datereq + "\n \n \n");
            }

            rdr.Close();
            sqlConnection.Close();

        }

    }
        }
    
